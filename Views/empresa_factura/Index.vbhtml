@ModelType IEnumerable(Of mmpLibrerias.empresa_factura)
@Code
ViewData("Title") = "Index"
Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Ventas Realizadas</h2>
<p>FILTRO POR FECHA</p>

<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.ventadocumento_venta_codigo_c25)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.ventadocumento_venta_NroControl_lon)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.ventadocumento_venta_fecha_dat)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.ventadocumento_fecha_modificacion_dat)
        </th>
         <th>
            @Html.DisplayNameFor(Function(model) model.cliente_codigo_c25)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.pais_id)
        </th>
         <th>
            @Html.DisplayNameFor(Function(model) model.canalventa_nombre_nom)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.total_item_precioventatotal_dec)
        </th>
         <th>
            @Html.DisplayNameFor(Function(model) model.total_item_costototal_dec)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
          <td>
            @Html.DisplayFor(Function(modelItem) item.ventadocumento_venta_codigo_c25)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.ventadocumento_venta_NroControl_lon)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.ventadocumento_venta_fecha_dat)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.ventadocumento_fecha_modificacion_dat)
        </td>
          <td>
            @Html.DisplayFor(Function(modelItem) item.cliente_codigo_c25)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.pais_id)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.canalventa_nombre_nom)
        </td>
         <td>
            @Html.DisplayFor(Function(modelItem) item.total_item_precioventatotal_dec)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.total_item_costototal_dec)
        </td>
        <td>
            @Html.ActionLink("Modificiar", "Edit", New With {.id = item.ventadocumento_id}) |
            @Html.ActionLink("Detalles Venta", "Details", New With {.id = item.ventadocumento_id}) |
            @Html.ActionLink("Productos Vendidos", "../empresa_FacturaProducto/Index", New With {.id = item.ventadocumento_id}))
        </td>
    </tr>
Next

</table>
