using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyShop.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Basket",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TotalItems = table.Column<int>(nullable: false),
                    TotalPrice = table.Column<double>(nullable: false),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Basket", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserID = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Zip = table.Column<string>(nullable: true),
                    Completed = table.Column<bool>(nullable: false),
                    GrandTotal = table.Column<double>(nullable: false),
                    OrderDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ImageStuffedAnimal = table.Column<string>(nullable: true),
                    ImageAnimal = table.Column<string>(nullable: true),
                    Summary = table.Column<string>(nullable: true),
                    AmmountLeft = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    LineItemAmount = table.Column<double>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    OrderID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BasketItems",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BasketID = table.Column<int>(nullable: false),
                    ProductID = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    LineItemAmount = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketItems", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BasketItems_Basket_BasketID",
                        column: x => x.BasketID,
                        principalTable: "Basket",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BasketItems_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ID", "AmmountLeft", "Description", "ImageAnimal", "ImageStuffedAnimal", "Name", "Price", "Summary" },
                values: new object[,]
                {
                    { 1, 43, "Name a pangolin and receive a plush.", "https://pangolinblob.blob.core.windows.net/wildplanetimages/pangolin.jpg", "https://pangolinblob.blob.core.windows.net/wildplanetimages/pangolinplush.jpg", "Pangolin", 2.0, "Large-scale trafficking is driven by a belief in pangolins’ magical and curative properties and a demand for their meat. When mixed with bark from certain trees, the scales are thought to neutralize witchcraft and evil spirits. If buried near a man’s door they are said to give an interested woman power over him. The smoke from their scales is thought to improve cattle health, keep lions away, and cure ailments like nose-bleeds.  Although their scales are made of keratin—the same substance that makes up human hair and nails—they are in high demand in certain Asian countries where the scales are believed to cure illnesses ranging from cancer to asthma, and their meat is considered a delicacy. In some areas, tribes believe a pangolin sighting indicates there will be a drought and the only way to prevent it is by killing the animal." },
                    { 2, 43, "Name an Amur Leopard and receive a plush.", "https://pangolinblob.blob.core.windows.net/wildplanetimages/amurleopard.jpg", "https://pangolinblob.blob.core.windows.net/wildplanetimages/amurleopardplush.jpg", "Amur Leopard", 2.0, "People usually think of leopards in the savannas of Africa but in the Russian Far East, a rare subspecies has adapted to life in the temperate forests that make up the northern-most part of the species’ range. Similar to other leopards, the Amur leopard can run at speeds of up to 37 miles per hour. This incredible animal has been reported to leap more than 19 feet horizontally and up to 10 feet vertically. The Amur leopard is solitary.Nimble - footed and strong, it carries and hides unfinished kills so that they are not taken by other predators.It has been reported that some males stay with females after mating, and may even help with rearing the young.Several males sometimes follow and fight over a female.They live for 10 - 15 years, and in captivity up to 20 years.The Amur leopard is also known as the Far East leopard, the Manchurian leopard or the Korean leopard." },
                    { 3, 43, "Name a Sumatran Orangutan and receive a plush.", "https://pangolinblob.blob.core.windows.net/wildplanetimages/sumatranorangutan.jpg", "https://pangolinblob.blob.core.windows.net/wildplanetimages/sumatranorangutanplush.jpg", "Sumatran Orangutan", 2.0, "Temp" },
                    { 4, 43, "Name a Cross River Gorilla and receive a plush.", "https://pangolinblob.blob.core.windows.net/wildplanetimages/silverback.jpg", "https://pangolinblob.blob.core.windows.net/wildplanetimages/silverbackplush.jpg", "Cross River Gorilla", 2.0, "Temp." },
                    { 5, 43, "Name a Hawksbill Sea Turtle and receive a plush.", "https://pangolinblob.blob.core.windows.net/wildplanetimages/hawksbill.jpg", "https://pangolinblob.blob.core.windows.net/wildplanetimages/hawksbillplush.jpg", "Hawksbill Sea Turtle", 2.0, "Temp." },
                    { 6, 43, "Name a Sumatran Tiger and receive a plush.", "https://pangolinblob.blob.core.windows.net/wildplanetimages/sumatrantiger.jpg", "https://pangolinblob.blob.core.windows.net/wildplanetimages/sumatrantigerplush.jpg", "Sumatran Tiger", 2.0, "Temp." },
                    { 7, 43, "Name a Black Rhino and receive a plush.", "https://pangolinblob.blob.core.windows.net/wildplanetimages/blackrhino.jpg", "https://pangolinblob.blob.core.windows.net/wildplanetimages/blackrhinoplush.jpg", "Black Rhino", 2.0, "Temp." },
                    { 8, 43, "Name a Snow Leopard and receive a plush.", "https://pangolinblob.blob.core.windows.net/wildplanetimages/snowleopard.jpg", "https://pangolinblob.blob.core.windows.net/wildplanetimages/snowleopardplush.jpg", "Snow Leopard", 2.0, "Temp." },
                    { 9, 43, "Name a Polar Bear and receive a plush.", "https://pangolinblob.blob.core.windows.net/wildplanetimages/polar.jpg", "https://pangolinblob.blob.core.windows.net/wildplanetimages/polarplush.jpg", "Polar Bear", 2.0, "Temp." },
                    { 10, 43, "Name a Giant Panda and receive a plush.", "https://pangolinblob.blob.core.windows.net/wildplanetimages/panda.jpg", "https://pangolinblob.blob.core.windows.net/wildplanetimages/pandaplush.jpg", "Giant Panda", 2.0, "Temp." }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_BasketID",
                table: "BasketItems",
                column: "BasketID");

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_ProductID",
                table: "BasketItems",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderID",
                table: "OrderItems",
                column: "OrderID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasketItems");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Basket");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
