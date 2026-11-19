namespace Portfolio.Content;

public static class Texts
{
    public static SiteContent For(Lang lang) => lang == Lang.En ? En : Es;

    private static readonly IReadOnlyList<string> SummaryStack = ["SQL Server", "T-SQL", "Datos DBF", "ECharts"];

    public static readonly SiteContent Es = new(
        Lang: Lang.Es,
        HtmlLang: "es-AR",
        PageTitle: "Lucas Correa · Desarrollador .NET y SQL Server",
        MetaDescription: "Desarrollador .NET en General Las Heras. Sistemas de gestión tipo ERP, modelado y migración de datos en SQL Server y tableros de gestión.",
        CvFile: "cv/CV_Lucas_Correa.pdf",
        Nav: new("Sobre mí", "Proyectos", "Habilidades", "Formación", "Contacto", "Descargar CV", "EN", "/en"),
        Hero: new(
            Greeting: "Hola, soy Lucas Correa",
            Role: "Desarrollador .NET · SQL Server · Modelado de datos",
            Pitch: "Construyo sistemas de gestión: modelos de datos que ordenan la operación, migraciones desde sistemas heredados y tableros que responden en milisegundos.",
            Location: "General Las Heras, Buenos Aires",
            CtaWork: "Ver proyectos",
            CtaCv: "Descargar CV",
            Available: "Disponible para trabajo remoto, híbrido o presencial"),
        About: new(
            Title: "Sobre mí",
            Paragraphs:
            [
                "Durante más de un año y medio trabajé en la suite de gestión a medida (tipo ERP) de una empresa de transporte de pasajeros del AMBA, con más de 180 líneas y unas 6.000 unidades. Entré como pasante haciendo QA y testing, y al mes pasé a desarrollador efectivo.",
                "Diseñé desde cero los módulos de Personal, Stock y Siniestros, y participé en los de Flota, Combustible, Neumáticos, Conductores, Licitaciones, Gestión de Auxilio y Seguridad.",
                "Mi fuerte es la base de datos: diseñar tablas y relaciones, llevar datos de sistemas viejos a uno nuevo y lograr que las consultas sobre millones de registros respondan rápido. También doy soporte de hardware, Windows y redes.",
                "Hoy me estoy formando en desarrollo de aplicaciones con IA (Python, LLMs, RAG y MCP), y en C#, .NET 10 y Angular. Este sitio está hecho con .NET 10.",
            ],
            Highlights:
            [
                new("12 s → 0,1 s", "consultas sobre ~18 M de registros"),
                new("3 módulos", "diseñados desde cero: Personal, Stock y Siniestros"),
            ]),
        Experience: new(
            Title: "Experiencia",
            Company: "Código Nativo",
            Client: "Cliente: DOTA, transporte de pasajeros del AMBA",
            Period: "abr. 2025 – nov. 2026",
            Mode: "Remoto",
            Stages: ["Desarrollador .NET · may. 2025 – nov. 2026", "Pasante de QA / Testing · abr. 2025 – may. 2025"]),
        Work: new(
            Title: "Proyectos",
            Intro: "Cuatro trabajos que muestran cómo pienso un sistema de gestión, de la base de datos a la pantalla.",
            ProblemLabel: "El problema",
            SolutionLabel: "Lo que hice",
            ResultLabel: "Resultado",
            Note: "Los diagramas muestran la estructura con nombres simplificados. No incluyen código ni datos del cliente.",
            Cases:
            [
                new(
                    Id: "tablas-resumen",
                    Tag: "Rendimiento · Datos heredados",
                    Title: "De 12 segundos a menos de 0,1",
                    Summary: "Tablas resumen sobre 18 millones de registros de un sistema de horarios heredado en DBF.",
                    Problem: "Los tableros de siniestros necesitaban kilómetros recorridos y choferes asignados por línea, unidad y día. Esos datos vivían en una tabla de horarios traída de un sistema viejo en DBF, con más de 18 millones de filas y campos guardados como texto. Cada consulta tenía que convertir y agrupar todo de nuevo.",
                    Solution: "Diseñé dos tablas resumen que se calculan una sola vez: kilómetros por línea, unidad y día (5,9 millones de filas) y choferes asignados (legajos) por línea, unidad y día (11,5 millones). En la carga limpio los datos: conversión segura de tipos, descarte de registros inválidos y filtro de años. Las tablas tienen clave e índice por línea, unidad y fecha.",
                    Result: "Consultas equivalentes a las del tablero bajaron de unos 12 segundos a menos de 0,1: más de 100 veces más rápidas. Lo medí sobre la misma base, con tres corridas por consulta.",
                    Stack: SummaryStack,
                    Diagram: Diagram.SummaryTables,
                    DiagramCaption: "Los datos se agregan una vez y los tableros leen solo el resumen."),
                new(
                    Id: "stock",
                    Tag: "Modelado de datos · Inventario",
                    Title: "Modelo de movimientos de stock",
                    Summary: "Entradas, salidas, ajustes y envíos entre depósitos con trazabilidad completa.",
                    Problem: "El área de stock necesitaba saber en todo momento qué había en cada depósito y ubicación, y por qué cambió: compras, consumos por centro de costo o por unidad, ajustes y envíos entre depósitos que pueden llegar con diferencias.",
                    Solution: "Diseñé el modelo de movimientos: una cabecera y su detalle, un catálogo de tipos de movimiento que indica si cada uno suma o resta, motivos de ajuste, centros de costo y un circuito de envío con estados. Desarrollé las operaciones: movimientos internos, envíos y recepción, salidas, ajustes y la carga del stock inicial importado.",
                    Result: "Cada cambio de stock queda registrado con su origen. Un envío nace pendiente y se cierra como recibido correctamente o recibido con diferencia, sin que el stock quede descuadrado.",
                    Stack: ["SQL Server", "Stored Procedures", "VB.NET", "ASP.NET"],
                    Diagram: Diagram.StockFlow,
                    DiagramCaption: "Un envío entre depósitos descuenta en origen y suma en destino solo al confirmarse la recepción."),
                new(
                    Id: "personal",
                    Tag: "Diseño de módulo · RR.HH.",
                    Title: "Módulo de Personal desde cero",
                    Summary: "El legajo y sus tablas maestras, la base para liquidar sueldos.",
                    Problem: "La empresa necesitaba centralizar los datos de su personal con todo lo que hace falta para liquidar sueldos: datos laborales, familiares, bancarios, sindicales y de ARCA.",
                    Solution: "Diseñé y desarrollé el módulo completo, base de datos y pantallas: el legajo del empleado y sus maestros, entre ellos bancos y cuentas, sindicatos y convenios, obras sociales, categorías salariales, centros de costo, conceptos ARCA, feriados y modalidades de contratación.",
                    Result: "Las tablas maestras quedan relacionadas con el legajo, cada una con su alta, baja y modificación, y los datos quedan listos para la liquidación de sueldos.",
                    Stack: ["SQL Server", "VB.NET", "ASP.NET", "JavaScript"],
                    Diagram: Diagram.PersonnelModel,
                    DiagramCaption: "El legajo en el centro y los maestros que lo completan."),
                new(
                    Id: "siniestros",
                    Tag: "Módulo nuevo · Integraciones",
                    Title: "Siniestros con mapas y tableros",
                    Summary: "Registro completo del siniestro, geolocalización con Google Maps y estadísticas.",
                    Problem: "La empresa necesitaba registrar cada siniestro con todos sus datos, ubicarlo en el mapa y analizar dónde y cómo ocurren.",
                    Solution: "Diseñé desde cero el módulo y sus tablas: el hecho, lesionados, daños, denuncias y evidencia fotográfica. Integré la API de Google Maps con autocompletado de direcciones para guardar la ubicación exacta. Armé tableros con ECharts (índice de gravedad, rankings y evolución mensual) y un mapa de calor de zonas críticas sobre Google Maps, con exportación a PDF. Sumé un optimizador que comprime las fotos antes de guardarlas y migré los partes históricos del sistema anterior.",
                    Result: "Cada siniestro queda en el mapa y la gerencia ve dónde se concentran los hechos y cómo evolucionan.",
                    Stack: ["SQL Server", "Google Maps API", "ECharts", "VB.NET", "JavaScript"],
                    Diagram: Diagram.ClaimsMap,
                    DiagramCaption: "De la dirección cargada al punto en el mapa de calor."),
            ]),
        Skills: new(
            Title: "Habilidades",
            Groups:
            [
                new("Bases de datos", ["SQL Server", "T-SQL", "Stored Procedures", "Optimización de consultas", "Tablas resumen", "MySQL"]),
                new("Modelado y migración", ["Diseño de tablas y relaciones", "Normalización", "Migración de datos heredados (DBF)"]),
                new("Desarrollo", ["VB.NET", "ASP.NET / ASPX", ".NET Framework", "JavaScript", "jQuery"]),
                new("Integraciones y tableros", ["API de Google Maps", "ECharts", "Exportación a PDF"]),
                new("Soporte e infraestructura", ["Armado y reparación de PC", "BIOS y booteo", "Windows", "Redes TCP/IP y cableado", "Cámaras con DVR"]),
                new("Herramientas", ["Git", "Bitbucket", "Jira", "Postman"]),
                new("En formación", ["C#", ".NET 10", "Angular", "Python", "LLMs, RAG y MCP"]),
            ]),
        Education: new(
            Title: "Formación",
            InProgressLabel: "En curso",
            Items:
            [
                new("Técnico Analista de Sistemas, Desarrollo de Software", "ISFDyT N° 44", "2021 – 2024", false),
                new("Desarrollo de aplicaciones con IA: Python, LLMs, RAG, tool use y MCP", "Anthropic Academy y DeepLearning.AI", "En curso, 2026", true, "https://www.anthropic.com/learn"),
            ]),
        Contact: new(
            Title: "Contacto",
            Pitch: "Busco sumarme a un equipo de sistemas de gestión. Si tenés una búsqueda o querés charlar, escribime.",
            EmailLabel: "Escribime",
            LinkedInLabel: "LinkedIn",
            CvLabel: "Descargar CV (PDF)"),
        Footer: "Hecho con .NET 10 y Tailwind CSS.");

    public static readonly SiteContent En = new(
        Lang: Lang.En,
        HtmlLang: "en",
        PageTitle: "Lucas Correa · .NET and SQL Server Developer",
        MetaDescription: ".NET developer based in Buenos Aires, Argentina. ERP-style business systems, SQL Server data modeling and migration, and management dashboards.",
        CvFile: "cv/CV_Lucas_Correa.pdf",
        Nav: new("About", "Projects", "Skills", "Education", "Contact", "Download CV", "ES", "/"),
        Hero: new(
            Greeting: "Hi, I'm Lucas Correa",
            Role: ".NET Developer · SQL Server · Data modeling",
            Pitch: "I build business management systems: data models that organize operations, migrations from legacy systems, and dashboards that answer in milliseconds.",
            Location: "General Las Heras, Buenos Aires, Argentina",
            CtaWork: "See projects",
            CtaCv: "Download CV",
            Available: "Available for remote, hybrid or on-site work"),
        About: new(
            Title: "About me",
            Paragraphs:
            [
                "For over a year and a half I worked on a custom ERP-style management suite for a passenger transport company in Greater Buenos Aires, with 180+ bus lines and about 6,000 vehicles. I joined as an intern doing QA and testing, and after a month I was hired as a permanent developer.",
                "I designed the Personnel, Stock and Incidents modules from scratch, and worked on the Fleet, Fuel, Tires, Drivers, Tenders, Roadside Assistance and Security modules.",
                "My strength is the database: designing tables and relationships, moving data from old systems into new ones, and making queries over millions of rows fast. I also handle hardware, Windows and network support.",
                "I'm currently learning to build AI applications (Python, LLMs, RAG and MCP), as well as C#, .NET 10 and Angular. This site is built with .NET 10.",
            ],
            Highlights:
            [
                new("12 s → 0.1 s", "queries over ~18M rows"),
                new("3 modules", "designed from scratch: Personnel, Stock and Incidents"),
            ]),
        Experience: new(
            Title: "Experience",
            Company: "Código Nativo",
            Client: "Client: DOTA, passenger transport, Greater Buenos Aires",
            Period: "Apr 2025 – Nov 2026",
            Mode: "Remote",
            Stages: [".NET Developer · May 2025 – Nov 2026", "QA / Testing Intern · Apr 2025 – May 2025"]),
        Work: new(
            Title: "Projects",
            Intro: "Four pieces of work that show how I think about a business system, from the database to the screen.",
            ProblemLabel: "The problem",
            SolutionLabel: "What I did",
            ResultLabel: "Result",
            Note: "Diagrams show the structure with simplified names. They contain no client code or data.",
            Cases:
            [
                new(
                    Id: "tablas-resumen",
                    Tag: "Performance · Legacy data",
                    Title: "From 12 seconds to under 0.1",
                    Summary: "Summary tables over 18 million rows from a legacy DBF scheduling system.",
                    Problem: "The incident dashboards needed kilometers driven and assigned drivers per line, vehicle and day. That data lived in a schedule table imported from an old DBF system, with more than 18 million rows and fields stored as text. Every query had to convert and aggregate everything again.",
                    Solution: "I designed two summary tables computed once: kilometers per line, vehicle and day (5.9 million rows) and assigned drivers per line, vehicle and day (11.5 million). The load cleans the data: safe type conversion, discarding invalid rows and filtering years. Both tables are keyed and indexed by line, vehicle and date.",
                    Result: "Queries equivalent to the dashboard's went from about 12 seconds to under 0.1: over 100 times faster. Measured on the same database, three runs per query.",
                    Stack: ["SQL Server", "T-SQL", "DBF data", "ECharts"],
                    Diagram: Diagram.SummaryTables,
                    DiagramCaption: "Data is aggregated once and dashboards read only the summary."),
                new(
                    Id: "stock",
                    Tag: "Data modeling · Inventory",
                    Title: "Stock movement model",
                    Summary: "Receipts, issues, adjustments and transfers between warehouses, fully traceable.",
                    Problem: "The stock team needed to know at any moment what was in each warehouse and location, and why it changed: purchases, consumption by cost center or vehicle, adjustments, and transfers that can arrive with differences.",
                    Solution: "I designed the movement model: a header and its lines, a catalog of movement types that says whether each one adds or subtracts, adjustment reasons, cost centers, and a transfer flow with states. I built the operations: internal moves, transfers and receipt, issues, adjustments and the import of opening stock.",
                    Result: "Every stock change is recorded with its origin. A transfer starts as pending and closes as received correctly or received with a difference, without leaving stock out of balance.",
                    Stack: ["SQL Server", "Stored Procedures", "VB.NET", "ASP.NET"],
                    Diagram: Diagram.StockFlow,
                    DiagramCaption: "A transfer subtracts at the source and adds at the destination only when receipt is confirmed."),
                new(
                    Id: "personal",
                    Tag: "Module design · HR",
                    Title: "Personnel module from scratch",
                    Summary: "The employee record and its master tables, the basis for payroll.",
                    Problem: "The company needed to centralize its staff data with everything payroll requires: employment, family, banking, union and tax authority (ARCA) data.",
                    Solution: "I designed and built the whole module, database and screens: the employee record and its master tables, including banks and accounts, unions and agreements, health insurers, salary categories, cost centers, tax concepts, holidays and contract types.",
                    Result: "Every master table is linked to the employee record, each with create, edit and delete screens, leaving the data ready for payroll.",
                    Stack: ["SQL Server", "VB.NET", "ASP.NET", "JavaScript"],
                    Diagram: Diagram.PersonnelModel,
                    DiagramCaption: "The employee record at the center and the master tables around it."),
                new(
                    Id: "siniestros",
                    Tag: "New module · Integrations",
                    Title: "Incidents with maps and dashboards",
                    Summary: "Full incident records, Google Maps geolocation and statistics.",
                    Problem: "The company needed to record every vehicle incident with all its details, place it on a map and analyze where and how incidents happen.",
                    Solution: "I designed the module and its tables from scratch: the incident, injured people, damages, police reports and photo evidence. I integrated the Google Maps API with address autocomplete to store the exact location. I built ECharts dashboards (severity index, rankings and monthly trend) and a heat map of critical areas on Google Maps, with PDF export. I added an optimizer that compresses photos before saving them and migrated historical records from the previous system.",
                    Result: "Every incident lands on the map, and management can see where incidents cluster and how they evolve.",
                    Stack: ["SQL Server", "Google Maps API", "ECharts", "VB.NET", "JavaScript"],
                    Diagram: Diagram.ClaimsMap,
                    DiagramCaption: "From the typed address to a point on the heat map."),
            ]),
        Skills: new(
            Title: "Skills",
            Groups:
            [
                new("Databases", ["SQL Server", "T-SQL", "Stored Procedures", "Query optimization", "Summary tables", "MySQL"]),
                new("Modeling and migration", ["Table and relationship design", "Normalization", "Legacy data migration (DBF)"]),
                new("Development", ["VB.NET", "ASP.NET / ASPX", ".NET Framework", "JavaScript", "jQuery"]),
                new("Integrations and dashboards", ["Google Maps API", "ECharts", "PDF export"]),
                new("Support and infrastructure", ["PC building and repair", "BIOS and boot", "Windows", "TCP/IP networks and cabling", "DVR security cameras"]),
                new("Tools", ["Git", "Bitbucket", "Jira", "Postman"]),
                new("Currently learning", ["C#", ".NET 10", "Angular", "Python", "LLMs, RAG and MCP"]),
            ]),
        Education: new(
            Title: "Education",
            InProgressLabel: "In progress",
            Items:
            [
                new("Systems Analyst Technician, Software Development", "ISFDyT N° 44", "2021 – 2024", false),
                new("Building AI applications: Python, LLMs, RAG, tool use and MCP", "Anthropic Academy and DeepLearning.AI", "In progress, 2026", true, "https://www.anthropic.com/learn"),
            ]),
        Contact: new(
            Title: "Contact",
            Pitch: "I'm looking to join a team working on business management systems. If you have an opening or want to talk, get in touch.",
            EmailLabel: "Email me",
            LinkedInLabel: "LinkedIn",
            CvLabel: "Download CV (PDF, Spanish)"),
        Footer: "Built with .NET 10 and Tailwind CSS.");
}
