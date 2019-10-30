@ModelType IEnumerable(Of mmpLibrerias.empresa_incidenciatipo)
@Code
ViewData("Title") = "Index"
Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Incidencias</h2>

<p>
    @Html.ActionLink("Crear Nuevo Tipo de Incidencias", "Create")
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
             @code
                 Dim routeValues As IDictionary(Of String, Object) = New Dictionary(Of String, Object)()
                 routeValues.Add("id", item.incidenciatipo_id)
                 routeValues.Add("nombretipo", item.incidenciatipo_nombre_nom)
             End Code

             @Html.ActionLink("Detalle de Incidencias", "../empresa_incidenciadetalle/Index", New RouteValueDictionary(routeValues)) |
             @Html.ActionLink("Editar", "Edit", New With {.id = item.incidenciatipo_id}) |
             @Html.ActionLink("Eliminar", "Delete", New With {.id = item.incidenciatipo_id})


         </td>
    </tr>
Next

</table>
