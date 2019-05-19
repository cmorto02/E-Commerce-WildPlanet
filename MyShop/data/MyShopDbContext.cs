using Microsoft.EntityFrameworkCore;
using MyShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.data
{
    public class MyShopDbContext : DbContext
    {
        public MyShopDbContext(DbContextOptions<MyShopDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ID = 1,
                    Name = "Pangolin",
                    Price = 2.00,
                    Description = "Name a pangolin and receive a plush.",
                    ImageStuffedAnimal = "https://pangolinblob.blob.core.windows.net/wildplanetimages/pangolinplush.jpg",
                    ImageAnimal = "https://pangolinblob.blob.core.windows.net/wildplanetimages/pangolin.jpg",
                    Summary = "Large-scale trafficking is driven by a belief in pangolins’ magical and curative properties and a demand for their meat. When mixed with bark from certain trees, the scales are thought to neutralize witchcraft and evil spirits. If buried near a man’s door they are said to give an interested woman power over him. The smoke from their scales is thought to improve cattle health, keep lions away, and cure ailments like nose-bleeds.  Although their scales are made of keratin—the same substance that makes up human hair and nails—they are in high demand in certain Asian countries where the scales are believed to cure illnesses ranging from cancer to asthma, and their meat is considered a delicacy. In some areas, tribes believe a pangolin sighting indicates there will be a drought and the only way to prevent it is by killing the animal.",
                    AmmountLeft = 43,
                },
                new Product
                {
                    ID = 2,
                    Name = "Amur Leopard",
                    Price = 2.00,
                    Description = "Name an Amur Leopard and receive a plush.",
                    ImageStuffedAnimal = "https://pangolinblob.blob.core.windows.net/wildplanetimages/amurleopardplush.jpg",
                    ImageAnimal = "https://pangolinblob.blob.core.windows.net/wildplanetimages/amurleopard.jpg",
                    Summary = "People usually think of leopards in the savannas of Africa but in the Russian Far East, a rare subspecies has adapted to life in the temperate forests that make up the northern-most part of the species’ range. Similar to other leopards, the Amur leopard can run at speeds of up to 37 miles per hour. This incredible animal has been reported to leap more than 19 feet horizontally and up to 10 feet vertically. The Amur leopard is solitary.Nimble - footed and strong, it carries and hides unfinished kills so that they are not taken by other predators.It has been reported that some males stay with females after mating, and may even help with rearing the young.Several males sometimes follow and fight over a female.They live for 10 - 15 years, and in captivity up to 20 years.The Amur leopard is also known as the Far East leopard, the Manchurian leopard or the Korean leopard.",
                    AmmountLeft = 43,
                },
                new Product
                {
                    ID = 3,
                    Name = "Sumatran Orangutan",
                    Price = 2.00,
                    Description = "Name a Sumatran Orangutan and receive a plush.",
                    ImageStuffedAnimal = "https://pangolinblob.blob.core.windows.net/wildplanetimages/sumatranorangutanplush.jpg",
                    ImageAnimal = "https://pangolinblob.blob.core.windows.net/wildplanetimages/sumatranorangutan.jpg",
                    Summary = "Temp",
                    AmmountLeft = 43,
                },
                new Product
                {
                    ID = 4,
                    Name = "Cross River Gorilla",
                    Price = 2.00,
                    Description = "Name a Cross River Gorilla and receive a plush.",
                    ImageStuffedAnimal = "https://pangolinblob.blob.core.windows.net/wildplanetimages/silverbackplush.jpg",
                    ImageAnimal = "https://pangolinblob.blob.core.windows.net/wildplanetimages/silverback.jpg",
                    Summary = "Temp.",
                    AmmountLeft = 43,
                },
                new Product
                {
                    ID = 5,
                    Name = "Hawksbill Sea Turtle",
                    Price = 2.00,
                    Description = "Name a Hawksbill Sea Turtle and receive a plush.",
                    ImageStuffedAnimal = "https://pangolinblob.blob.core.windows.net/wildplanetimages/hawksbillplush.jpg",
                    ImageAnimal = "https://pangolinblob.blob.core.windows.net/wildplanetimages/hawksbill.jpg",
                    Summary = "Temp.",
                    AmmountLeft = 43,
                },
                new Product
                {
                    ID = 6,
                    Name = "Sumatran Tiger",
                    Price = 2.00,
                    Description = "Name a Sumatran Tiger and receive a plush.",
                    ImageStuffedAnimal = "https://pangolinblob.blob.core.windows.net/wildplanetimages/sumatrantigerplush.jpg",
                    ImageAnimal = "https://pangolinblob.blob.core.windows.net/wildplanetimages/sumatrantiger.jpg",
                    Summary = "Temp.",
                    AmmountLeft = 43,
                },
                new Product
                {
                    ID = 7,
                    Name = "Black Rhino",
                    Price = 2.00,
                    Description = "Name a Black Rhino and receive a plush.",
                    ImageStuffedAnimal = "https://pangolinblob.blob.core.windows.net/wildplanetimages/blackrhinoplush.jpg",
                    ImageAnimal = "https://pangolinblob.blob.core.windows.net/wildplanetimages/blackrhino.jpg",
                    Summary = "Temp.",
                    AmmountLeft = 43,
                },
                new Product
                {
                    ID = 8,
                    Name = "Snow Leopard",
                    Price = 2.00,
                    Description = "Name a Snow Leopard and receive a plush.",
                    ImageStuffedAnimal = "https://pangolinblob.blob.core.windows.net/wildplanetimages/snowleopardplush.jpg",
                    ImageAnimal = "https://pangolinblob.blob.core.windows.net/wildplanetimages/snowleopard.jpg",
                    Summary = "Temp.",
                    AmmountLeft = 43,
                },
                new Product
                {
                    ID = 9,
                    Name = "Polar Bear",
                    Price = 2.00,
                    Description = "Name a Polar Bear and receive a plush.",
                    ImageStuffedAnimal = "https://pangolinblob.blob.core.windows.net/wildplanetimages/polarplush.jpg",
                    ImageAnimal = "https://pangolinblob.blob.core.windows.net/wildplanetimages/polar.jpg",
                    Summary = "Temp.",
                    AmmountLeft = 43,
                },
                new Product
                {
                    ID = 10,
                    Name = "Giant Panda",
                    Price = 2.00,
                    Description = "Name a Giant Panda and receive a plush.",
                    ImageStuffedAnimal = "https://pangolinblob.blob.core.windows.net/wildplanetimages/pandaplush.jpg",
                    ImageAnimal = "https://pangolinblob.blob.core.windows.net/wildplanetimages/panda.jpg",
                    Summary = "Temp.",
                    AmmountLeft = 43,
                });
        }

        /// <summary>
        /// sets the use and creation of tables through models of the following:
        /// </summary>
        public DbSet<Product> Product { get; set; }
        public DbSet<Basket> Basket { get; set; }
        public DbSet<BasketItems> BasketItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }
    }
}
