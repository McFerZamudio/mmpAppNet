<head>
    <style type="text/css">
        .auto-style1 {
            width: 65px;
            height: 65px;
        }
    </style>
</head>
@ModelType IEnumerable(Of mmpLibrerias.empresa_FacturaProducto)
@Code
ViewData("Title") = "Index"
Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Detalle Producto Vendido</h2>

<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.Factura.ventadocumento_venta_codigo_c25)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.producto_codigo_txt)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Producto_imagen_txt)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.producto_nombre_txt)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.producto_unidades_dec)
        </th>
           <th>
            @Html.DisplayNameFor(Function(model) model.producto_preciocompra_dec)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.producto_beneficio_dec)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.producto_incidencia_txt)
        </th>
        <th></th>
    </tr>

    @For Each item In Model
        @<tr>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Factura.ventadocumento_venta_codigo_c25)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.producto_codigo_txt)
            </td>
            <td>
                <img src="@Html.DisplayFor(Function(modelItem) item.Producto_imagen_txt)" class="auto-style1"/>
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.producto_nombre_txt)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.producto_unidades_dec)
            </td>
             <td>
                @Html.DisplayFor(Function(modelItem) item.producto_preciocompra_dec)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.producto_beneficio_dec)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.producto_incidencia_txt)
            </td>
            <td>
                @Html.ActionLink("Modificar", "Edit", New With {.id = item.ventaproduco_id}) |
                @Html.ActionLink("Detalles", "Details", New With {.id = item.ventaproduco_id}) |
                @Html.ActionLink("Eliminar?", "Delete", New With {.id = item.ventaproduco_id})
            </td>
        </tr>
    Next
    <p>
        @Html.ActionLink("Regresar a Ventas Realizadas", "../empresa_Factura/Index")
    </p>
</table>
