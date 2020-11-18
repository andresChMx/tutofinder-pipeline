using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace TutoFinder.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Nombres = table.Column<string>(maxLength: 20, nullable: false),
                    Apellidos = table.Column<string>(maxLength: 20, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    CursoId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(maxLength: 30, nullable: false),
                    Descripcion = table.Column<string>(maxLength: 100, nullable: false),
                    Grado_academico = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.CursoId);
                });

            migrationBuilder.CreateTable(
                name: "Docentes",
                columns: table => new
                {
                    DocenteId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombres = table.Column<string>(maxLength: 20, nullable: false),
                    Apellidos = table.Column<string>(maxLength: 20, nullable: false),
                    DNI = table.Column<string>(maxLength: 9, nullable: false),
                    Domicilio = table.Column<string>(maxLength: 100, nullable: false),
                    Correo = table.Column<string>(maxLength: 50, nullable: false),
                    Disponibilidad = table.Column<string>(maxLength: 20, nullable: false),
                    Numero_cuenta = table.Column<string>(maxLength: 20, nullable: false),
                    Membresia = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Docentes", x => x.DocenteId);
                });

            migrationBuilder.CreateTable(
                name: "Padres",
                columns: table => new
                {
                    PadreId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombres = table.Column<string>(maxLength: 20, nullable: false),
                    Apellidos = table.Column<string>(maxLength: 20, nullable: false),
                    DNI = table.Column<string>(maxLength: 9, nullable: false),
                    Correo = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Padres", x => x.PadreId);
                });

            migrationBuilder.CreateTable(
                name: "Tarjetas",
                columns: table => new
                {
                    TarjetaId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Fecha_expiracion = table.Column<string>(maxLength: 10, nullable: false),
                    Nombre_poseedor = table.Column<string>(maxLength: 20, nullable: false),
                    Numero_tarjeta = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarjetas", x => x.TarjetaId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
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
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
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
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
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
                name: "Alumnos",
                columns: table => new
                {
                    AlumnoId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PadreId = table.Column<int>(nullable: false),
                    Nombres = table.Column<string>(maxLength: 20, nullable: false),
                    Apellidos = table.Column<string>(maxLength: 20, nullable: false),
                    DNI = table.Column<string>(maxLength: 9, nullable: false),
                    Grado_academico = table.Column<string>(maxLength: 20, nullable: false),
                    Correo = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alumnos", x => x.AlumnoId);
                    table.ForeignKey(
                        name: "FK_Alumnos_Padres_PadreId",
                        column: x => x.PadreId,
                        principalTable: "Padres",
                        principalColumn: "PadreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Favoritos",
                columns: table => new
                {
                    FavoritoId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PadreId = table.Column<int>(nullable: false),
                    DocenteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favoritos", x => x.FavoritoId);
                    table.ForeignKey(
                        name: "FK_Favoritos_Docentes_DocenteId",
                        column: x => x.DocenteId,
                        principalTable: "Docentes",
                        principalColumn: "DocenteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Favoritos_Padres_PadreId",
                        column: x => x.PadreId,
                        principalTable: "Padres",
                        principalColumn: "PadreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Membresias",
                columns: table => new
                {
                    MembresiaId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Cvc_tarjeta = table.Column<string>(maxLength: 3, nullable: false),
                    Fecha_expiracion = table.Column<string>(maxLength: 10, nullable: false),
                    TarjetaId = table.Column<int>(nullable: false),
                    DocenteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Membresias", x => x.MembresiaId);
                    table.ForeignKey(
                        name: "FK_Membresias_Docentes_DocenteId",
                        column: x => x.DocenteId,
                        principalTable: "Docentes",
                        principalColumn: "DocenteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Membresias_Tarjetas_TarjetaId",
                        column: x => x.TarjetaId,
                        principalTable: "Tarjetas",
                        principalColumn: "TarjetaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tutorias",
                columns: table => new
                {
                    TutoriaId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AlumnoId = table.Column<int>(nullable: false),
                    CursoId = table.Column<int>(nullable: false),
                    DocenteId = table.Column<int>(nullable: false),
                    Costo = table.Column<double>(nullable: false),
                    Descripcion = table.Column<string>(maxLength: 50, nullable: false),
                    Cantidad_minutos = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tutorias", x => x.TutoriaId);
                    table.ForeignKey(
                        name: "FK_Tutorias_Alumnos_AlumnoId",
                        column: x => x.AlumnoId,
                        principalTable: "Alumnos",
                        principalColumn: "AlumnoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tutorias_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "CursoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tutorias_Docentes_DocenteId",
                        column: x => x.DocenteId,
                        principalTable: "Docentes",
                        principalColumn: "DocenteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Informes",
                columns: table => new
                {
                    InformeId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TutoriaId = table.Column<int>(nullable: false),
                    Descripcion = table.Column<string>(maxLength: 50, nullable: false),
                    Fecha = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Informes", x => x.InformeId);
                    table.ForeignKey(
                        name: "FK_Informes_Tutorias_TutoriaId",
                        column: x => x.TutoriaId,
                        principalTable: "Tutorias",
                        principalColumn: "TutoriaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    PagoId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TarjetaId = table.Column<int>(nullable: false),
                    TutoriaId = table.Column<int>(nullable: false),
                    Descripcion = table.Column<string>(maxLength: 50, nullable: false),
                    CvcTarjeta = table.Column<string>(maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagos", x => x.PagoId);
                    table.ForeignKey(
                        name: "FK_Pagos_Tarjetas_TarjetaId",
                        column: x => x.TarjetaId,
                        principalTable: "Tarjetas",
                        principalColumn: "TarjetaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pagos_Tutorias_TutoriaId",
                        column: x => x.TutoriaId,
                        principalTable: "Tutorias",
                        principalColumn: "TutoriaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "adc5214e-7ce8-40d6-a57c-a032e70a03e5", "a1b3ccf9-7d46-40c0-aaf4-6ebc1b780e47", "ADMIN", "ADMIN" },
                    { "c4150151-4375-42b9-986a-8515c3086825", "2e6a2e17-10b6-44d0-9305-7e526db94c5e", "PADRE", "PADRE" },
                    { "b8050c59-747f-4ab9-b6ef-e67f59f91d96", "61009079-293f-42be-a957-84ae7b66f2dc", "DOCENTE", "DOCENTE" }
                });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "CursoId", "Descripcion", "Grado_academico", "Nombre" },
                values: new object[] { 1, "aquellas herramientas que los usuarios pueden utilizar accediendo a un servidor web de internet", "Secundaria", "AplicacionesWeb" });

            migrationBuilder.InsertData(
                table: "Docentes",
                columns: new[] { "DocenteId", "Apellidos", "Correo", "DNI", "Disponibilidad", "Domicilio", "Membresia", "Nombres", "Numero_cuenta" },
                values: new object[] { 1, " Mendoza", "henrry@gmail.com", "16534786", "No Disponible", "San Miguel calle puquina los condominios la waka", "Activa", " Henrry", "2534586198371450" });

            migrationBuilder.InsertData(
                table: "Padres",
                columns: new[] { "PadreId", "Apellidos", "Correo", "DNI", "Nombres" },
                values: new object[] { 1, "Cahuana", "Moieses@hotmail.com", " 35826791", " Moises" });

            migrationBuilder.InsertData(
                table: "Tarjetas",
                columns: new[] { "TarjetaId", "Fecha_expiracion", "Nombre_poseedor", "Numero_tarjeta" },
                values: new object[] { 1, "20/02/2025", " Henry Papi", "255.255.255.0" });

            migrationBuilder.InsertData(
                table: "Alumnos",
                columns: new[] { "AlumnoId", "Apellidos", "Correo", "DNI", "Grado_academico", "Nombres", "PadreId" },
                values: new object[] { 1, "Cardenas", "lucho13@gmail.com", "75863340", "Secundaria", "Lucho", 1 });

            migrationBuilder.InsertData(
                table: "Membresias",
                columns: new[] { "MembresiaId", "Cvc_tarjeta", "DocenteId", "Fecha_expiracion", "TarjetaId" },
                values: new object[] { 1, "123", 1, "12/05/2021", 1 });

            migrationBuilder.InsertData(
                table: "Tutorias",
                columns: new[] { "TutoriaId", "AlumnoId", "Cantidad_minutos", "Costo", "CursoId", "Descripcion", "DocenteId" },
                values: new object[] { 1, 1, 3, 30.25, 1, "Repaso de codigo Api", 1 });

            migrationBuilder.InsertData(
                table: "Informes",
                columns: new[] { "InformeId", "Descripcion", "Fecha", "TutoriaId" },
                values: new object[] { 1, " no hizo nada en todo el ciclo", "12/02/2000", 1 });

            migrationBuilder.InsertData(
                table: "Pagos",
                columns: new[] { "PagoId", "CvcTarjeta", "Descripcion", "TarjetaId", "TutoriaId" },
                values: new object[] { 1, "123", " Pago de tutoria de redes", 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Alumnos_PadreId",
                table: "Alumnos",
                column: "PadreId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

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
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Favoritos_DocenteId",
                table: "Favoritos",
                column: "DocenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Favoritos_PadreId",
                table: "Favoritos",
                column: "PadreId");

            migrationBuilder.CreateIndex(
                name: "IX_Informes_TutoriaId",
                table: "Informes",
                column: "TutoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Membresias_DocenteId",
                table: "Membresias",
                column: "DocenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Membresias_TarjetaId",
                table: "Membresias",
                column: "TarjetaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_TarjetaId",
                table: "Pagos",
                column: "TarjetaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_TutoriaId",
                table: "Pagos",
                column: "TutoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Tutorias_AlumnoId",
                table: "Tutorias",
                column: "AlumnoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tutorias_CursoId",
                table: "Tutorias",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tutorias_DocenteId",
                table: "Tutorias",
                column: "DocenteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "Favoritos");

            migrationBuilder.DropTable(
                name: "Informes");

            migrationBuilder.DropTable(
                name: "Membresias");

            migrationBuilder.DropTable(
                name: "Pagos");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Tarjetas");

            migrationBuilder.DropTable(
                name: "Tutorias");

            migrationBuilder.DropTable(
                name: "Alumnos");

            migrationBuilder.DropTable(
                name: "Cursos");

            migrationBuilder.DropTable(
                name: "Docentes");

            migrationBuilder.DropTable(
                name: "Padres");
        }
    }
}
