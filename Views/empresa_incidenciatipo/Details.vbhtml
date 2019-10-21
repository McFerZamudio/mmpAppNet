@ModelType mmpLibrerias.empresa_incidenciatipo
@Code
    ViewData("Title") = "Details"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Details</h2>

<div>
    <h4>empresa_incidenciatipo</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.empresa.empresa_nombre_nom)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.empresa.empresa_nombre_nom)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.incidenciatipo_nombre_nom)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.incidenciatipo_nombre_nom)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.incidenciatipo_id }) |
    @Html.ActionLink("Back to List", "Index")
</p>
