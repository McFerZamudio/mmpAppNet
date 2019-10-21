@ModelType IEnumerable(Of mmpLibrerias.empresa_incidenciatipo)
@Code
ViewData("Title") = "Index"
Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Index</h2>

<p>
    @Html.ActionLink("Crear Nuevo", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.incidenciatipo_nombre_nom)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
         <td>
            @Html.DisplayFor(Function(modelItem) item.incidenciatipo_nombre_nom)
        </td>
         <td>
             @Html.ActionLink("Editar", "Edit", New With {.id = item.incidenciatipo_id}) |
             @Html.ActionLink("Detalles", "Details", New With {.id = item.incidenciatipo_id}) |
             @Html.ActionLink("Eliminar", "Delete", New With {.id = item.incidenciatipo_id})
             @Html.ActionLink("Detalle de Incidencia", "../empresa_incidenciadetalle/Index", New With {.id = item.incidenciatipo_id})

         </td>
    </tr>
Next

</table>
