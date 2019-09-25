@ModelType mmpLibrerias.empresa_FacturaProducto
@Code
    ViewData("Title") = "Delete"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
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
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
            <input type="submit" value="Delete" class="btn btn-default" /> |
            @Html.ActionLink("Back to List", "Index")
        </div>
    End Using
</div>
