# Julio26WinFormsValidacion

Como correr el proyecto

1) En app.config, modificar la base de datos

```xml
  <connectionStrings>
    <add name="Pedidos" connectionString="data source=PCJC\SQLDEV;initial catalog=BaseJunio;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework" providerName="System.Data.SqlClient" />
    <add name="BasePedido" connectionString="data source=PCJC\SQLDEV;initial catalog=BaseJunio;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework" providerName="System.Data.SqlClient" />
  </connectionStrings>
```

2) En la tabla Producto, falta la columna Stock (entero)

