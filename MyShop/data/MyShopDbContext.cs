﻿using Microsoft.EntityFrameworkCore;
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
                    ID = 0,
                    Name = "Pangolin",
                    Price = 2400.00,
                    Description = "Name a pangolin and receive a plush.",
                    ImageStuffedAnimal = "https://images-na.ssl-images-amazon.com/images/I/7194O4jEGnL._SY355_.jpg",
                    ImageAnimal = "http://yesofcorsa.com/wp-content/uploads/2017/06/Pangolin-Best-Wallpaper-1024x646.jpg",
                    Summary = "Large-scale trafficking is driven by a belief in pangolins’ magical and curative properties and a demand for their meat. When mixed with bark from certain trees, the scales are thought to neutralize witchcraft and evil spirits. If buried near a man’s door they are said to give an interested woman power over him. The smoke from their scales is thought to improve cattle health, keep lions away, and cure ailments like nose-bleeds.  Although their scales are made of keratin—the same substance that makes up human hair and nails—they are in high demand in certain Asian countries where the scales are believed to cure illnesses ranging from cancer to asthma, and their meat is considered a delicacy. In some areas, tribes believe a pangolin sighting indicates there will be a drought and the only way to prevent it is by killing the animal.",
                    AmmountLeft = 43,
                },
                new Product
                {
                    ID = 1,
                    Name = "Amur Leopard",
                    Price = 2400.00,
                    Description = "Name an Amur Leopard and receive a plush.",
                    ImageStuffedAnimal = "https://i.ebayimg.com/images/g/NQEAAOSwHntbmfbP/s-l300.jpg",
                    ImageAnimal = "http://cdn.animalhi.com/2560x1600/20121027/animals%20leopards%20amur%20leopard%202560x1600%20wallpaper_www.animalhi.com_40.jpg",
                    Summary = "People usually think of leopards in the savannas of Africa but in the Russian Far East, a rare subspecies has adapted to life in the temperate forests that make up the northern-most part of the species’ range. Similar to other leopards, the Amur leopard can run at speeds of up to 37 miles per hour. This incredible animal has been reported to leap more than 19 feet horizontally and up to 10 feet vertically. The Amur leopard is solitary.Nimble - footed and strong, it carries and hides unfinished kills so that they are not taken by other predators.It has been reported that some males stay with females after mating, and may even help with rearing the young.Several males sometimes follow and fight over a female.They live for 10 - 15 years, and in captivity up to 20 years.The Amur leopard is also known as the Far East leopard, the Manchurian leopard or the Korean leopard.",
                    AmmountLeft = 43,
                },
                new Product
                {
                    ID = 2,
                    Name = "Sumatran Orangutan",
                    Price = 2400.00,
                    Description = "Name a Sumatran Orangutan and receive a plush.",
                    ImageStuffedAnimal = "https://zoostore.zoo.org/media/catalog/product/cache/6b1c09900b407c50fce2db5e66ebc123/1/2/12250-orangutan.jpg",
                    ImageAnimal = "https://ak8.picdn.net/shutterstock/videos/30904708/thumb/1.jpg",
                    Summary = "Temp",
                    AmmountLeft = 43,
                },
                new Product
                {
                    ID = 3,
                    Name = "Cross River Gorilla",
                    Price = 2400.00,
                    Description = "Name a Cross River Gorilla and receive a plush.",
                    ImageStuffedAnimal = "https://images-na.ssl-images-amazon.com/images/I/7194O4jEGnL._SY355_.jpg",
                    ImageAnimal = "http://yesofcorsa.com/wp-content/uploads/2017/06/Pangolin-Best-Wallpaper-1024x646.jpg",
                    Summary = "Temp.",
                    AmmountLeft = 43,
                },
                new Product
                {
                    ID = 4,
                    Name = "Hawksbill Sea Turtle",
                    Price = 2400.00,
                    Description = "Name a Hawksbill Sea Turtle and receive a plush.",
                    ImageStuffedAnimal = "https://images-na.ssl-images-amazon.com/images/I/7194O4jEGnL._SY355_.jpg",
                    ImageAnimal = "http://yesofcorsa.com/wp-content/uploads/2017/06/Pangolin-Best-Wallpaper-1024x646.jpg",
                    Summary = "Temp.",
                    AmmountLeft = 43,
                },
                new Product
                {
                    ID = 5,
                    Name = "Sumatran Tiger",
                    Price = 2400.00,
                    Description = "Name a Sumatran Tiger and receive a plush.",
                    ImageStuffedAnimal = "https://images-na.ssl-images-amazon.com/images/I/7194O4jEGnL._SY355_.jpg",
                    ImageAnimal = "http://yesofcorsa.com/wp-content/uploads/2017/06/Pangolin-Best-Wallpaper-1024x646.jpg",
                    Summary = "Temp.",
                    AmmountLeft = 43,
                },
                new Product
                {
                    ID = 6,
                    Name = "Black Rhino",
                    Price = 2400.00,
                    Description = "Name a Black Rhino and receive a plush.",
                    ImageStuffedAnimal = "https://images-na.ssl-images-amazon.com/images/I/7194O4jEGnL._SY355_.jpg",
                    ImageAnimal = "http://yesofcorsa.com/wp-content/uploads/2017/06/Pangolin-Best-Wallpaper-1024x646.jpg",
                    Summary = "Temp.",
                    AmmountLeft = 43,
                },
                new Product
                {
                    ID = 7,
                    Name = "Snow Leopard",
                    Price = 2400.00,
                    Description = "Name a Snow Leopard and receive a plush.",
                    ImageStuffedAnimal = "https://images-na.ssl-images-amazon.com/images/I/7194O4jEGnL._SY355_.jpg",
                    ImageAnimal = "http://yesofcorsa.com/wp-content/uploads/2017/06/Pangolin-Best-Wallpaper-1024x646.jpg",
                    Summary = "Temp.",
                    AmmountLeft = 43,
                },
                new Product
                {
                    ID = 8,
                    Name = "Polar Bear",
                    Price = 2400.00,
                    Description = "Name a Polar Bear and receive a plush.",
                    ImageStuffedAnimal = "https://images-na.ssl-images-amazon.com/images/I/7194O4jEGnL._SY355_.jpg",
                    ImageAnimal = "http://yesofcorsa.com/wp-content/uploads/2017/06/Pangolin-Best-Wallpaper-1024x646.jpg",
                    Summary = "Temp.",
                    AmmountLeft = 43,
                },
                new Product
                {
                    ID = 9,
                    Name = "Giant Panda",
                    Price = 2400.00,
                    Description = "Name a Giant Panda and receive a plush.",
                    ImageStuffedAnimal = "https://images-na.ssl-images-amazon.com/images/I/7194O4jEGnL._SY355_.jpg",
                    ImageAnimal = "http://yesofcorsa.com/wp-content/uploads/2017/06/Pangolin-Best-Wallpaper-1024x646.jpg",
                    Summary = "Temp.",
                    AmmountLeft = 43,
                });
        }
        public DbSet<Product> products { get; set; }
    }
}
