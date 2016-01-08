using BestPracticesPlayground.Entities;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BestPracticesPlayground
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new BestPracticesDbContext();

            context.Database.Initialize(true);

            var account = new Account()
            {
                AccountName = "El Al Cargo",
                Settings = new Settings()
                {
                    MaxPickupsPerCar = 3,
                    MaxTripDuration = 75,
                    MinPickupsPerCar = 2
                }
            };
            context.Accounts.Add(account);
            context.SaveChanges();

            var user = new User()
            {
                Username = "ChenKK",
                LastLogin = DateTime.Now,
                Email = "ckchenkeren@gmail.com",
                AccessibleAccounts = new List<AccountUsers>()
                        {
                            new AccountUsers()
                            {
                                AuthorizationLevel = new AuthorizationLevel()
                                {
                                    Description = "admin"
                                },
                                AccountId = account.Id
                            }
                        }
            };
            context.Users.Add(user);
            context.SaveChanges();

            var destinationAddress = new Address()
            {
                IsArchived = false,
                FirstLine = "502 Shoreham Rd",
                SecondLine = "London Heatrow Airport , Hounslow",
                PostCode = "TW6 3UA",
                City = "London",
                Country = "United Kingdom"
            };
            context.Addresses.Add(destinationAddress);
            context.SaveChanges();

            var contactAddress = new Address()
            {
                FirstLine = "6 Bridgeman House",
                SecondLine = "Pump House Crescent",
                PostCode = "TW8 0FX",
                City = "London",
                Country = "United Kingdom",
            };
            context.Addresses.Add(contactAddress);
            context.SaveChanges();

            var contact = new Contact()
            {
                FirstName = "Chen",
                LastName = "Keren Kaminsky",
                Email = "ckchenkeren@gmail.com",
                Phone = "07474772070",
                IsArchived = false,
                PrimaryAddressId = contactAddress.Id
            };
            context.Contacts.Add(contact);
            context.SaveChanges();

            contact.ContactAddresses.Add(new ContactAddresses()
            {
                Contact = contact,
                Address = contactAddress
            });

            var mailingContact = new Contact()
            {
                FirstName = "Dina",
                LastName = "Barel",
                Email = "ckchenkeren@gmail.com",
                Phone = "0208000000",
                IsArchived = false,
                PrimaryAddressId = null,
            };
            context.Contacts.Add(mailingContact);
            context.SaveChanges();

            var mailingList = new MailingList()
            {
                Name = "Default"
            };
            context.MailingLists.Add(mailingList);
            context.SaveChanges();

            mailingList.MailingListContacts.Add(new MailingListContact()
            {
                Contact = mailingContact,
                MailingList = mailingList
            });

            account.AccountDestinations.Add(new AccountDestinations()
            {
                Account = account,
                Address = destinationAddress,
                AddressNickname = "Cargo Warehouse"
            });

            account.MailingLists.Add(mailingList);

            context.SaveChanges();




            var storedAccount = context.Accounts.FirstOrDefault();

            if (storedAccount != null)
            {
                Console.WriteLine(storedAccount.AccountName);
                Console.WriteLine("Settings:\n{0}\n{1}\n{2}", storedAccount.Settings.MaxPickupsPerCar, storedAccount.Settings.MaxTripDuration,
                    storedAccount.Settings.MinPickupsPerCar);
                Console.WriteLine("Contacts:");
                foreach (var cnt in storedAccount.Contacts)
                {
                    Console.WriteLine(cnt.FirstName + " " + cnt.LastName);
                    Console.WriteLine("Primary Address:");
                    Console.WriteLine(cnt.ContactAddresses.FirstOrDefault(a => a.Address.Id == cnt.PrimaryAddressId).Address.FirstLine);
                }
                Console.WriteLine("Destinations: ");
                foreach (var dst in storedAccount.AccountDestinations)
                {
                    Console.WriteLine(dst.AddressNickname + ": " + dst.Address.FirstLine);
                }
                Console.WriteLine("Mailing Lists:");
                foreach (var mailList in storedAccount.MailingLists)
                {
                    Console.WriteLine(mailList.Name + ": ");
                    foreach (var mcnt in mailList.MailingListContacts)
                    {
                        Console.WriteLine(mcnt.Contact.FirstName + ": " + mcnt.Contact.Email);
                    }
                }
            }
            else
            {
                Console.WriteLine("No recordes found");
            }


            Console.WriteLine("Done! Press any key to exit.");
            Console.ReadKey();
        }
    }
}

