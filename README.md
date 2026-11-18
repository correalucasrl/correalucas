# correalucas.com

Portfolio de Lucas Correa. Hecho con **.NET 10 (Blazor, renderizado en el servidor)** y **Tailwind CSS v4**. Bilingüe: español en `/` e inglés en `/en`.

## Estructura

```
src/Portfolio/
  Content/          Textos del sitio en español e inglés (Texts.cs) y su modelo (SiteContent.cs)
  Components/
    Pages/Home.razor        La página (rutas "/" y "/en")
    Sections/               Encabezado, secciones y diagramas de los proyectos
  Styles/app.css    Estilos fuente de Tailwind (colores, componentes)
  wwwroot/          Archivos públicos: css/site.css (generado), cv/, favicon
deploy.ps1          Publicación en Azure App Service
```

Para cambiar un texto, editá `src/Portfolio/Content/Texts.cs` (están las dos versiones, `Es` y `En`).

## Desarrollo local

```bash
npm install
npm run css
dotnet run --project src/Portfolio --launch-profile http
```

El sitio queda en http://localhost:5239. Mientras editás estilos o clases, dejá corriendo `npm run css:watch` en otra terminal.

## Publicar en Azure

Primera vez (crea la web app en tu plan Basic existente):

```bash
az login
az webapp create --resource-group <grupo> --plan <plan-basic> --name <nombre-app> --runtime "DOTNETCORE:10.0"
```

Cada publicación:

```bash
powershell -ExecutionPolicy Bypass -File deploy.ps1 -App <nombre-app> -ResourceGroup <grupo>
```

### Dominio correalucas.com

1. En el panel de tu registrador de dominio, creá:
   - un registro **TXT** `asuid` con el ID de verificación de la web app (Azure lo muestra en *Dominios personalizados*),
   - un registro **A** `@` apuntando a la IP de la web app, y un **CNAME** `www` → `<nombre-app>.azurewebsites.net`.
2. Agregá el dominio y el certificado gratuito administrado:

```bash
az webapp config hostname add --resource-group <grupo> --webapp-name <nombre-app> --hostname correalucas.com
az webapp config ssl create --resource-group <grupo> --name <nombre-app> --hostname correalucas.com
```
