using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyShop.Migrations.MyShopDb
{
    public partial class initial : Migration
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
                    { 1, 43, "Name a pangolin and receive a plush.", "http://yesofcorsa.com/wp-content/uploads/2017/06/Pangolin-Best-Wallpaper-1024x646.jpg", "https://images-na.ssl-images-amazon.com/images/I/7194O4jEGnL._SY355_.jpg", "Pangolin", 2400.0, "Large-scale trafficking is driven by a belief in pangolins’ magical and curative properties and a demand for their meat. When mixed with bark from certain trees, the scales are thought to neutralize witchcraft and evil spirits. If buried near a man’s door they are said to give an interested woman power over him. The smoke from their scales is thought to improve cattle health, keep lions away, and cure ailments like nose-bleeds.  Although their scales are made of keratin—the same substance that makes up human hair and nails—they are in high demand in certain Asian countries where the scales are believed to cure illnesses ranging from cancer to asthma, and their meat is considered a delicacy. In some areas, tribes believe a pangolin sighting indicates there will be a drought and the only way to prevent it is by killing the animal." },
                    { 2, 43, "Name an Amur Leopard and receive a plush.", "http://cdn.animalhi.com/2560x1600/20121027/animals%20leopards%20amur%20leopard%202560x1600%20wallpaper_www.animalhi.com_40.jpg", "https://i.ebayimg.com/images/g/NQEAAOSwHntbmfbP/s-l300.jpg", "Amur Leopard", 2400.0, "People usually think of leopards in the savannas of Africa but in the Russian Far East, a rare subspecies has adapted to life in the temperate forests that make up the northern-most part of the species’ range. Similar to other leopards, the Amur leopard can run at speeds of up to 37 miles per hour. This incredible animal has been reported to leap more than 19 feet horizontally and up to 10 feet vertically. The Amur leopard is solitary.Nimble - footed and strong, it carries and hides unfinished kills so that they are not taken by other predators.It has been reported that some males stay with females after mating, and may even help with rearing the young.Several males sometimes follow and fight over a female.They live for 10 - 15 years, and in captivity up to 20 years.The Amur leopard is also known as the Far East leopard, the Manchurian leopard or the Korean leopard." },
                    { 3, 43, "Name a Sumatran Orangutan and receive a plush.", "https://ak8.picdn.net/shutterstock/videos/30904708/thumb/1.jpg", "https://zoostore.zoo.org/media/catalog/product/cache/6b1c09900b407c50fce2db5e66ebc123/1/2/12250-orangutan.jpg", "Sumatran Orangutan", 2400.0, "Temp" },
                    { 4, 43, "Name a Cross River Gorilla and receive a plush.", "http://www.manyaratravel.com/wp-content/uploads/2015/04/Gorilla-with-baby.jpg", "https://cdn3.volusion.com/9nxdj.fchy5/v/vspfiles/photos/AR-80431-2.jpg?1517907494", "Cross River Gorilla", 2400.0, "Temp." },
                    { 5, 43, "Name a Hawksbill Sea Turtle and receive a plush.", "https://voiceforthespeechless.com/wp-content/uploads/2017/02/hawksbill-seaturtle.png", "https://i.ebayimg.com/images/g/rwkAAOSw2BxafjbF/s-l640.jpg", "Hawksbill Sea Turtle", 2400.0, "Temp." },
                    { 6, 43, "Name a Sumatran Tiger and receive a plush.", "https://www.waza.org/wp-content/uploads/2019/02/sumatran-tiger-wz-gsmp-m.jpg", "https://image.dhgate.com/0x0s/f2-albu-g7-M01-75-01-rBVaSlsWKw2AZsz_AANSc4-UmmA074.jpg/raj-the-sumatran-tiger-19-inch-large-sumatran.jpg", "Sumatran Tiger", 2400.0, "Temp." },
                    { 7, 43, "Name a Black Rhino and receive a plush.", "https://www.helpingrhinos.org/userfiles/helpingrhinos.org/About%20Rhinos/Black-Rhino3-9-flip.jpg", "https://images-na.ssl-images-amazon.com/images/I/71M7U89W78L._SX425_.jpg", "Black Rhino", 2400.0, "Temp." },
                    { 8, 43, "Name a Snow Leopard and receive a plush.", "https://k6u8v6y8.stackpathcdn.com/blog/wp-content/uploads/2019/01/Snow-Leopard.jpg", "https://gifts.worldwildlife.org/gift-center/images/species-adoptions/Snow-Leopard/Snow-Leopard-plush-z1.jpg", "Snow Leopard", 2400.0, "Temp." },
                    { 9, 43, "Name a Polar Bear and receive a plush.", "https://media.treehugger.com/assets/images/2018/10/polar-bear-kid.jpg.860x0_q70_crop-scale.jpg", "https://images-na.ssl-images-amazon.com/images/I/611900XLxiL._SX425_.jpg", "Polar Bear", 2400.0, "Temp." },
                    { 10, 43, "Name a Giant Panda and receive a plush.", "https://www.sciencenews.org/sites/default/files/2019/01/main/articles/013019_JR_panda-diet_feat.jpg", "https://images-na.ssl-images-amazon.com/images/I/71rbxOLyUSL._SX425_.jpg", "Giant Panda", 2400.0, "Temp." }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_BasketID",
                table: "BasketItems",
                column: "BasketID");

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_ProductID",
                table: "BasketItems",
                column: "ProductID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasketItems");

            migrationBuilder.DropTable(
                name: "Basket");

            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
