using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentAssociationAPI.Migrations
{
    public partial class InitialSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", null, "Admin", "ADMIN" },
                    { "2", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Associations",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { "1", "<< Oameni obisnuiti >>  ~ Hadirca Dionisie", "ASMI" },
                    { "2", "<< Oameni evlaviosi >>  ~ Hadirca Dionisie", "Asociatia Evanghelistilor" },
                    { "3", "<< Nu cunosc acesti oameni >>  ~ Hadirca Dionisie", "AS Stiinte Aplicate" },
                    { "4", "<< Daca ai avea Facebook ai sti >>  ~ Hadirca Dionisie", "Asociatia Fizicienilor Romani" }
                });

            migrationBuilder.InsertData(
                table: "Commitees",
                columns: new[] { "Id", "AssociationId", "Description", "InaugurationDate", "Name" },
                values: new object[,]
                {
                    { "1", "1", "Principalul nostru obiectiv este sa imbunatatim conditiile in care decurg evenimentele asociatiei. Acest lucru il realizam prin supervizarea desfasurarii proiectelor ASMI si dezvoltarea acestora pe mai departe, dar si intrand in contact direct cu diverse firme (din domeniul IT si nu numai), cu care incheiem contracte de sponsorizare.", new DateTime(2019, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Management & Fundraising" },
                    { "2", "1", "Daca am putea descrie acest departament in doua cuvinte acelea sigur ar fi \"imaginea asociatiei\". Imagineaza-ti pentru cateva secunde cum ar arata un proiect fara afise, postari pe Facebook sau pe Instagram, de exemplu Recrutarile sau ce zici de o petrecere? Exact, informatia ar ajunge la mult mai putini oameni, sau cei care ar sti nu ar veni, deoarece nu i-a atras nimic auzind o informatie doar prin viu grai.", new DateTime(2016, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Design & PR" },
                    { "3", "1", "Departamentul Educational are ca scop imbunatatirea calitatii vietii academice a studentilor, reprezentand o punte de legatura intre acestia si Conducerea Facultatii. Cu ce se ocupa mai exact Edu? Proiecte precum Admiterea, Tutoriate, Ziua Portilor Deschise, Ratusca si, mai recent, Practica sunt organizate de voluntarii nostri, care sunt motivati sa ajute studentii sa aiba o experienta a anilor de Facultate cat mai placuta.", new DateTime(2017, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Educational" },
                    { "4", "1", "Noi suntem, in cateva cuvinte, \"inima asociatiei\"! Ne ocupam de integrarea bobocilor ce ni se alatura in fiecare toamna si primavara, astfel incat ei sa ajunga sa se simta cu adevarat parte din familia noastra, dar si de bunastarea tuturor voluntarilor, prin organizarea de joculete interactive si de activitati de socializare.", new DateTime(2016, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Human Resources" },
                    { "5", "3", "In cadrul acestui comitet are loc un mix de energie, originalitate si motivatie, conferit de prezenta si implicarea tinerilor. Datorita acestora, ideea de comunitate capata noi valente.", new DateTime(2020, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Planner" },
                    { "6", "3", "RIUF - The Romanian International University Fair, cel mai mare eveniment educational, international de universitati din Europa de Sud Est este locul in care peste 220.000 de elevi, studenti, profesori si parinti au discutat cu reprezentantii din peste 150 de universitati din intreaga lume.", new DateTime(2021, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "RIUF" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "CommiteeId", "Description", "EndTime", "IsCanceled", "Location", "Name", "StartTime" },
                values: new object[] { "1", "1", "Description 1", new DateTime(2021, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Campus UB", "Event 1", new DateTime(2021, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "CommiteeId", "Description", "EndTime", "IsCanceled", "Location", "Name", "StartTime" },
                values: new object[] { "2", "1", "Description 2", new DateTime(2021, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Campus UB", "Event 2", new DateTime(2021, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "CommiteeId", "Description", "EndTime", "IsCanceled", "Location", "Name", "StartTime" },
                values: new object[] { "3", "2", "Description 3", new DateTime(2021, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Campus UB", "Event 3", new DateTime(2021, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "Associations",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "Associations",
                keyColumn: "Id",
                keyValue: "4");

            migrationBuilder.DeleteData(
                table: "Commitees",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "Commitees",
                keyColumn: "Id",
                keyValue: "4");

            migrationBuilder.DeleteData(
                table: "Commitees",
                keyColumn: "Id",
                keyValue: "5");

            migrationBuilder.DeleteData(
                table: "Commitees",
                keyColumn: "Id",
                keyValue: "6");

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "Associations",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "Commitees",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "Commitees",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "Associations",
                keyColumn: "Id",
                keyValue: "1");
        }
    }
}
