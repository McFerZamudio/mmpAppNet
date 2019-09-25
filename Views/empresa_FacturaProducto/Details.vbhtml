@ModelType mmpLibrerias.empresa_FacturaProducto
@Code
    ViewData("Title") = "Details"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Details</h2>

<div>
    <h4>empresa_FacturaProducto</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Factura.ventadocumento_venta_codigo_c25)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Factura.ventadocumento_venta_codigo_c25)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.producto_codigo_txt)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.producto_codigo_txt)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Producto_imagen_txt)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Producto_imagen_txt)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.producto_nombre_txt)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.producto_nombre_txt)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.producto_unidades_dec)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.producto_unidades_dec)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.producto_sku_txt)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.producto_sku_txt)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.producto_enlace_txt)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.producto_enlace_txt)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.producto_preciocompra_dec)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.producto_preciocompra_dec)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.producto_beneficio_dec)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.producto_beneficio_dec)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.producto_incidencia_txt)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.producto_incidencia_txt)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.ventaproduco_id }) |
    @Html.ActionLink("Regresar", "Index/" & Model.ventaproduco_id)
</p>
