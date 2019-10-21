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

    Dim CodigoVenta As String = Request.QueryString("CodigoVenta")
End Code

<h2>Detalle Producto Vendido - Codigo Venta: @CodigoVenta</h2>

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
            Costo Unit
        </th>
        <th>
            Comision Unit
        </th>
        <th>
            Precio Unit
        </th>
        <th>
            Beneficio
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.producto_incidencia_txt)
        </th>
        <th>
        </th>
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
        <img src="@Html.DisplayFor(Function(modelItem) item.Producto_imagen_txt)" class="auto-style1" />
    </td>
    <td>
        @Html.DisplayFor(Function(modelItem) item.producto_nombre_txt)
    </td>
    <td>
        @Html.DisplayFor(Function(modelItem) item.producto_unidades_dec)
    </td>
    <td style="color:red">
        @code
            Dim CostoTotal As Decimal = Math.Round(item.producto_preciocompra_dec * item.producto_unidades_dec, 2)
        End Code
        @Html.DisplayFor(Function(modelItem) item.producto_preciocompra_dec)
        <p style="color:black"><strong>Costo Total:</strong><p>@CostoTotal</p></p>
    </td>
    <td style="color:red">
        @code
            Dim Comisiones As Decimal = item.producto_precioventa_dec - item.producto_preciocompra_dec - item.producto_beneficio_dec
            Dim ComisionesTotal As Decimal = Math.Round(Comisiones * item.producto_unidades_dec, 2)
        End Code
        @Comisiones
        <p style="color:black"><strong>Comision Total:</strong><p>@ComisionesTotal</p></p>
    </td>
    <td>
        @code
            Dim PrecioTotal As Decimal = Math.Round(item.producto_precioventa_dec * item.producto_unidades_dec, 2)
        End Code
        @Html.DisplayFor(Function(model) item.producto_precioventa_dec)
        <p><strong>Precio Total:</strong><p>@PrecioTotal</p></p>
    </td>
    <td style="color:darkgreen">
        @code
            Dim BeneficioTotal As Decimal = Math.Round(item.producto_beneficio_dec * item.producto_unidades_dec, 2)
        End Code
        @Html.DisplayFor(Function(modelItem) item.producto_beneficio_dec)
        <p style="color:black"><strong>Beneficio Total:</strong><p>@BeneficioTotal</p></p>
    </td>
    <td>
        @code
            Dim _incidencia As String = item.producto_incidencia_txt

            If _incidencia <> "" Then
                @<a href="" onclick="window.open('empresa_FacturaProductoIncidencia','Carga CSV','width=800,height=600')">Cargar Pedidos por CSV</a>
            Else
                @<label style="color:green">Sin incidencias</label>
            End If
        End Code
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
