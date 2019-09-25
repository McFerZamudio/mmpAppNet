@ModelType mmpLibrerias.empresa_factura
@Code
    ViewData("Title") = "Details"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Details</h2>

<div>
    <h4>empresa_factura</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Empresas.empresa_nombre_nom)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Empresas.empresa_nombre_nom)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.ventadocumento_venta_codigo_c25)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.ventadocumento_venta_codigo_c25)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.ventadocumento_venta_NroControl_lon)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.ventadocumento_venta_NroControl_lon)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.ventadocumento_venta_fecha_dat)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.ventadocumento_venta_fecha_dat)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.ventadocumento_fecha_modificacion_dat)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.ventadocumento_fecha_modificacion_dat)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.clientes_id)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.clientes_id)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.cliente_codigo_c25)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.cliente_codigo_c25)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.cliente_nombre_nom)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.cliente_nombre_nom)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.cliente_direccionfiscal_txt)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.cliente_direccionfiscal_txt)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.cliente_direccionenvio_txt)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.cliente_direccionenvio_txt)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.cliente_telefono_tel)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.cliente_telefono_tel)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.pais_id)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.pais_id)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.canalventas_id)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.canalventas_id)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.canalventa_nombre_nom)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.canalventa_nombre_nom)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.canalventa_comisionporc_dec)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.canalventa_comisionporc_dec)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.venta_comisioncanalventa_dec)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.venta_comisioncanalventa_dec)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.canalpagos_id)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.canalpagos_id)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.canalpago_nombre_nom)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.canalpago_nombre_nom)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.canalpago_comisionpago_dec)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.canalpago_comisionpago_dec)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.ventadocumento_descotrosgastos_txt)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.ventadocumento_descotrosgastos_txt)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.ventadocumento_totalotrosgastos_dec)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.ventadocumento_totalotrosgastos_dec)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.total_item_precioventatotal_dec)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.total_item_precioventatotal_dec)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.total_producto_comisionventa_dec)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.total_producto_comisionventa_dec)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.total_item_iva_dec)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.total_item_iva_dec)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.total_item_costototal_dec)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.total_item_costototal_dec)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.total_paquete_costotransporte_dec)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.total_paquete_costotransporte_dec)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.total_item_otroscostos_dec)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.total_item_otroscostos_dec)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.ventadocumento_id }) |
    @Html.ActionLink("Back to List", "Index")
</p>
