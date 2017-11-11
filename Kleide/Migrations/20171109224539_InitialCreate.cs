using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Kleide.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aksesuaru_kategorija",
                columns: table => new
                {
                    id_Aksesuaru_kategorija = table.Column<int>(type: "int", nullable: false),
                    pavadinimas = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aksesuaru_kategorija", x => x.id_Aksesuaru_kategorija);
                });

            migrationBuilder.CreateTable(
                name: "Asmuo",
                columns: table => new
                {
                    asmens_kodas = table.Column<int>(type: "int", nullable: false),
                    adresas = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    miestas = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    pasto_kodas = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    pavarde = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    salis = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    telefonas = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    vardas = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asmuo", x => x.asmens_kodas);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mokejimas",
                columns: table => new
                {
                    mokejimo_id = table.Column<int>(type: "int", nullable: false),
                    atsiskaitymo_būdas = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    atsiėmimo_vieta = table.Column<double>(type: "float", nullable: true),
                    data = table.Column<DateTime>(type: "date", nullable: true),
                    draudimo_tipas = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    mokejimo_busena = table.Column<string>(type: "char(10)", nullable: true),
                    nuolaidos_suma = table.Column<double>(type: "float", nullable: true),
                    sumoketa_suma = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mokejimas", x => x.mokejimo_id);
                });

            migrationBuilder.CreateTable(
                name: "Sandelys",
                columns: table => new
                {
                    id_Sandelys = table.Column<int>(type: "int", nullable: false),
                    darbo_masinos_kiekis = table.Column<int>(type: "int", nullable: true),
                    darbuotoju_kiekis = table.Column<int>(type: "int", nullable: true),
                    gatvės_pavadinimas = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    kiekis = table.Column<int>(type: "int", nullable: true),
                    kontaktinis_asmuo = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    miestas = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    pasto_kodas = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    prekes_bukle = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    prekes_tipas = table.Column<string>(type: "char(10)", nullable: true),
                    salis = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    sandelio_dydis = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sandelys", x => x.id_Sandelys);
                });

            migrationBuilder.CreateTable(
                name: "Vartotojas",
                columns: table => new
                {
                    id_Vartotojas = table.Column<int>(type: "int", nullable: false),
                    fk_Asmuoasmens_kodas = table.Column<int>(type: "int", nullable: false),
                    ip_adresas = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    prisijungimo_vardas = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    slaptazodis = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vartotojas", x => x.id_Vartotojas);
                    table.ForeignKey(
                        name: "yra",
                        column: x => x.fk_Asmuoasmens_kodas,
                        principalTable: "Asmuo",
                        principalColumn: "asmens_kodas",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Nuoma",
                columns: table => new
                {
                    nuomos_numeris = table.Column<int>(type: "int", nullable: false),
                    fk_Asmuoasmens_kodas = table.Column<int>(type: "int", nullable: false),
                    fk_Asmuoasmens_kodas1 = table.Column<int>(type: "int", nullable: false),
                    fk_Mokejimasmokejimo_id = table.Column<int>(type: "int", nullable: false),
                    grazinimo_data = table.Column<DateTime>(type: "date", nullable: true),
                    kaina = table.Column<double>(type: "float", nullable: true),
                    kuponas = table.Column<double>(type: "float", nullable: true),
                    pvm = table.Column<double>(type: "float", nullable: true),
                    rezervavimo_data = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nuoma", x => x.nuomos_numeris);
                    table.ForeignKey(
                        name: "patvirtina_2",
                        column: x => x.fk_Asmuoasmens_kodas,
                        principalTable: "Asmuo",
                        principalColumn: "asmens_kodas",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "atlieka",
                        column: x => x.fk_Asmuoasmens_kodas1,
                        principalTable: "Asmuo",
                        principalColumn: "asmens_kodas",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "uz",
                        column: x => x.fk_Mokejimasmokejimo_id,
                        principalTable: "Mokejimas",
                        principalColumn: "mokejimo_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pirkimas",
                columns: table => new
                {
                    uzsakymo_numeris = table.Column<int>(type: "int", nullable: false),
                    ar_apdrausta = table.Column<bool>(type: "bit", nullable: true),
                    data = table.Column<DateTime>(type: "date", nullable: true),
                    fk_Asmuoasmens_kodas = table.Column<int>(type: "int", nullable: false),
                    fk_Asmuoasmens_kodas1 = table.Column<int>(type: "int", nullable: false),
                    fk_Mokejimasmokejimo_id = table.Column<int>(type: "int", nullable: false),
                    kaina = table.Column<double>(type: "float", nullable: true),
                    kuponas = table.Column<double>(type: "float", nullable: true),
                    pvm = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pirkimas", x => x.uzsakymo_numeris);
                    table.ForeignKey(
                        name: "patvirtina_1",
                        column: x => x.fk_Asmuoasmens_kodas,
                        principalTable: "Asmuo",
                        principalColumn: "asmens_kodas",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "atlieka_1",
                        column: x => x.fk_Asmuoasmens_kodas1,
                        principalTable: "Asmuo",
                        principalColumn: "asmens_kodas",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "uz_1",
                        column: x => x.fk_Mokejimasmokejimo_id,
                        principalTable: "Mokejimas",
                        principalColumn: "mokejimo_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    id_Role = table.Column<int>(type: "int", nullable: false),
                    fk_Vartotojasid_Vartotojas = table.Column<int>(type: "int", nullable: false),
                    lygis = table.Column<int>(type: "int", nullable: true),
                    pavadinimas = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.id_Role);
                    table.ForeignKey(
                        name: "turi_2",
                        column: x => x.fk_Vartotojasid_Vartotojas,
                        principalTable: "Vartotojas",
                        principalColumn: "id_Vartotojas",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Preke",
                columns: table => new
                {
                    id_Preke = table.Column<int>(type: "int", nullable: false),
                    aprasymas = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    ar_ranku_darbo = table.Column<bool>(type: "bit", nullable: true),
                    bukle = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    dydis = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    fk_Nuomanuomos_numeris = table.Column<int>(type: "int", nullable: false),
                    fk_Pirkimasuzsakymo_numeris = table.Column<int>(type: "int", nullable: false),
                    fk_Sandelysid_Sandelys = table.Column<int>(type: "int", nullable: false),
                    nuomos_skaicius = table.Column<int>(type: "int", nullable: true),
                    nuotrauka = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    pagaminimo_salis = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    pavadinimas = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    pridejimo_data = table.Column<DateTime>(type: "date", nullable: true),
                    rezervavimo_tipas = table.Column<string>(type: "char(17)", nullable: true),
                    spalva = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preke", x => x.id_Preke);
                    table.ForeignKey(
                        name: "nuomoja",
                        column: x => x.fk_Nuomanuomos_numeris,
                        principalTable: "Nuoma",
                        principalColumn: "nuomos_numeris",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "perka",
                        column: x => x.fk_Pirkimasuzsakymo_numeris,
                        principalTable: "Pirkimas",
                        principalColumn: "uzsakymo_numeris",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "turi",
                        column: x => x.fk_Sandelysid_Sandelys,
                        principalTable: "Sandelys",
                        principalColumn: "id_Sandelys",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Aksesuaras",
                columns: table => new
                {
                    id_Aksesuaras = table.Column<int>(type: "int", nullable: false),
                    ar_elektroninis = table.Column<bool>(type: "bit", nullable: true),
                    ar_su_grandinele = table.Column<bool>(type: "bit", nullable: true),
                    fk_Aksesuaru_kategorijaid_Aksesuaru_kategorija = table.Column<int>(type: "int", nullable: false),
                    fk_Prekeid_Preke = table.Column<int>(type: "int", nullable: false),
                    lytis = table.Column<string>(type: "char(7)", nullable: true),
                    metalo_tipas = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aksesuaras", x => x.id_Aksesuaras);
                    table.ForeignKey(
                        name: "turi_1",
                        column: x => x.fk_Aksesuaru_kategorijaid_Aksesuaru_kategorija,
                        principalTable: "Aksesuaru_kategorija",
                        principalColumn: "id_Aksesuaru_kategorija",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "yra_2",
                        column: x => x.fk_Prekeid_Preke,
                        principalTable: "Preke",
                        principalColumn: "id_Preke",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Avalyne",
                columns: table => new
                {
                    id_Avalyne = table.Column<int>(type: "int", nullable: false),
                    fk_Prekeid_Preke = table.Column<int>(type: "int", nullable: false),
                    lytis = table.Column<string>(type: "char(7)", nullable: true),
                    medziagos_tipas = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    pobudis = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    su_kulniuku = table.Column<bool>(type: "bit", nullable: true),
                    uzsegimas = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avalyne", x => x.id_Avalyne);
                    table.ForeignKey(
                        name: "yra_1",
                        column: x => x.fk_Prekeid_Preke,
                        principalTable: "Preke",
                        principalColumn: "id_Preke",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Draudimas",
                columns: table => new
                {
                    id_Draudimas = table.Column<int>(type: "int", nullable: false),
                    draudimo_numeris = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    draudimo_suma = table.Column<double>(type: "float", nullable: true),
                    fk_Prekeid_Preke = table.Column<int>(type: "int", nullable: false),
                    pabaigos_data = table.Column<DateTime>(type: "date", nullable: true),
                    pobudis = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    pradzios_data = table.Column<DateTime>(type: "date", nullable: true),
                    tiekejas = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Draudimas", x => x.id_Draudimas);
                    table.ForeignKey(
                        name: "itraukatas",
                        column: x => x.fk_Prekeid_Preke,
                        principalTable: "Preke",
                        principalColumn: "id_Preke",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Suknele",
                columns: table => new
                {
                    sukneles_numeris = table.Column<int>(type: "int", nullable: false),
                    audinys = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    fk_Prekeid_Preke = table.Column<int>(type: "int", nullable: false),
                    ilgis = table.Column<double>(type: "float", nullable: true),
                    modelio_tipas = table.Column<string>(type: "char(9)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suknele", x => x.sukneles_numeris);
                    table.ForeignKey(
                        name: "yra_3",
                        column: x => x.fk_Prekeid_Preke,
                        principalTable: "Preke",
                        principalColumn: "id_Preke",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aksesuaras_fk_Aksesuaru_kategorijaid_Aksesuaru_kategorija",
                table: "Aksesuaras",
                column: "fk_Aksesuaru_kategorijaid_Aksesuaru_kategorija");

            migrationBuilder.CreateIndex(
                name: "UQ__Aksesuar__EFDEFA2005051911",
                table: "Aksesuaras",
                column: "fk_Prekeid_Preke",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ__Avalyne__EFDEFA206FBB2F18",
                table: "Avalyne",
                column: "fk_Prekeid_Preke",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Draudima__EFDEFA209C9C0485",
                table: "Draudimas",
                column: "fk_Prekeid_Preke",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Nuoma_fk_Asmuoasmens_kodas",
                table: "Nuoma",
                column: "fk_Asmuoasmens_kodas");

            migrationBuilder.CreateIndex(
                name: "IX_Nuoma_fk_Asmuoasmens_kodas1",
                table: "Nuoma",
                column: "fk_Asmuoasmens_kodas1");

            migrationBuilder.CreateIndex(
                name: "IX_Nuoma_fk_Mokejimasmokejimo_id",
                table: "Nuoma",
                column: "fk_Mokejimasmokejimo_id");

            migrationBuilder.CreateIndex(
                name: "IX_Pirkimas_fk_Asmuoasmens_kodas",
                table: "Pirkimas",
                column: "fk_Asmuoasmens_kodas");

            migrationBuilder.CreateIndex(
                name: "IX_Pirkimas_fk_Asmuoasmens_kodas1",
                table: "Pirkimas",
                column: "fk_Asmuoasmens_kodas1");

            migrationBuilder.CreateIndex(
                name: "IX_Pirkimas_fk_Mokejimasmokejimo_id",
                table: "Pirkimas",
                column: "fk_Mokejimasmokejimo_id");

            migrationBuilder.CreateIndex(
                name: "UQ__Preke__BF9E9BB67701A75D",
                table: "Preke",
                column: "fk_Nuomanuomos_numeris",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Preke__7E0206E7D43AA57F",
                table: "Preke",
                column: "fk_Pirkimasuzsakymo_numeris",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Preke_fk_Sandelysid_Sandelys",
                table: "Preke",
                column: "fk_Sandelysid_Sandelys");

            migrationBuilder.CreateIndex(
                name: "IX_Role_fk_Vartotojasid_Vartotojas",
                table: "Role",
                column: "fk_Vartotojasid_Vartotojas");

            migrationBuilder.CreateIndex(
                name: "UQ__Suknele__EFDEFA20D956F343",
                table: "Suknele",
                column: "fk_Prekeid_Preke",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Vartotoj__BFDBFAF0588FD67A",
                table: "Vartotojas",
                column: "fk_Asmuoasmens_kodas",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aksesuaras");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Avalyne");

            migrationBuilder.DropTable(
                name: "Draudimas");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Suknele");

            migrationBuilder.DropTable(
                name: "Aksesuaru_kategorija");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Vartotojas");

            migrationBuilder.DropTable(
                name: "Preke");

            migrationBuilder.DropTable(
                name: "Nuoma");

            migrationBuilder.DropTable(
                name: "Pirkimas");

            migrationBuilder.DropTable(
                name: "Sandelys");

            migrationBuilder.DropTable(
                name: "Asmuo");

            migrationBuilder.DropTable(
                name: "Mokejimas");
        }
    }
}
