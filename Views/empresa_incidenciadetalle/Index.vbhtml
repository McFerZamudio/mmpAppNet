@ModelType IEnumerable(Of mmpLibrerias.empresa_incidenciadetalle)
@Code
ViewData("Title") = "Index"
Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Index</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.empresa.empresa_nombre_nom)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.incidentetipo.incidenciatipo_nombre_nom)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.incidenciadetalle_nombre_txt)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.empresa.empresa_nombre_nom)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.incidentetipo.incidenciatipo_nombre_nom)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.incidenciadetalle_nombre_txt)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.incidenciadetalle_id }) |
            @Html.ActionLink("Details", "Details", New With {.id = item.incidenciadetalle_id }) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.incidenciadetalle_id })
        </td>
    </tr>
Next

</table>
