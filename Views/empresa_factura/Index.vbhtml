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
            Codigo de la Venta
        </th>
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
            @Html.DisplayNameFor(Function(model) model.Pais)
        </th>
        <th>
            Canal Venta
        </th>
        <th>
            Costo Total
        </th>
        <th>
           Precio Total
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
         <td>
             @Html.DisplayFor(Function(modelItem) item.ventadocumento_codigoventacanal_txt)
        </td>
         <td>
             @code
                 If IsNothing(item.ventadocumento_fecha_procesamiento_dat) = True Then
                     @Html.ActionLink("Factura: " & item.ventadocumento_venta_codigo_c25, "actionName", "controllerName", New With {Key .Id = "ids"}, New With {Key .target = "_blank", Key .width = "400px", Key .height = "400px", Key .modal = "yes"})
                 Else
                     @<label>-</label>
                 End If
                     End Code
         </td>
    <td>
        @Html.DisplayFor(Function(modelItem) item.ventadocumento_venta_NroControl_lon)
    </td>
    <td>
        @CODE
            Dim FechaCorta As String = Format(item.ventadocumento_venta_fecha_dat, "dd/MM/yyyy")
                     End Code
        @FechaCorta
    </td>
    <td>
        @CODE
            Dim FechaModificacion As String = Format(item.ventadocumento_fecha_modificacion_dat, "dd/MM/yyyy")
                     End Code
        @FechaModificacion
    </td>
    <td>
        @Html.DisplayFor(Function(modelItem) item.cliente_codigo_c25)
    </td>
    <td>
        @Html.DisplayFor(Function(modelItem) item.Pais.pais_nombre_nom)
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
        @code
            Dim routeValues As IDictionary(Of String, Object) = New Dictionary(Of String, Object)()
                     routeValues.Add("id", item.ventadocumento_id)
                     routeValues.Add("CodigoVenta", item.ventadocumento_codigoventacanal_txt)
                     End Code

        @Html.ActionLink("Modificiar", "Edit", New With {.id = item.ventadocumento_id}) |
        @Html.ActionLink("Detalles Venta", "Details", New With {.id = item.ventadocumento_id}) |
        @Html.ActionLink("Productos", "../empresa_FacturaProducto/Index", New RouteValueDictionary(routeValues)))
    </td>
</tr>
            Next

</table>
