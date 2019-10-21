@ModelType mmpLibrerias.empresa_incidenciadetalle
@Code
    ViewData("Title") = "Delete"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<div>
    <h4>empresa_incidenciadetalle</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.empresa.empresa_nombre_nom)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.empresa.empresa_nombre_nom)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.incidentetipo.incidenciatipo_nombre_nom)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.incidentetipo.incidenciatipo_nombre_nom)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.incidenciadetalle_nombre_txt)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.incidenciadetalle_nombre_txt)
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
