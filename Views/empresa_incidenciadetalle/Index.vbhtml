@ModelType IEnumerable(Of mmpLibrerias.empresa_incidenciadetalle)
@Code
    ViewData("Title") = "Index"
    Layout = "~/Views/Shared/_Layout.vbhtml"

    Dim _id As Long = Url.RequestContext.RouteData.Values("id")
    Dim _incidencia As String = Request.QueryString("nombretipo")

    '  _incidencia = Model.First().incidentetipo.incidenciatipo_nombre_nom

End Code




<h2>Detalles de @_incidencia </h2>

<p>
    @Html.ActionLink("Crear Nuevo Detalle de " & _incidencia, "Create", New With {.id = _id})
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.incidenciadetalle_nombre_txt)
        </th>
        <th></th>
    </tr>

    @For Each item In Model
        @<tr>
            <td>
                @Html.DisplayFor(Function(modelItem) item.incidenciadetalle_nombre_txt)
            </td>
            <td>
                @Html.ActionLink("Editar", "Edit", New With {.id = item.incidenciadetalle_id}) |
                @Html.ActionLink("Borrar", "Delete", New With {.id = item.incidenciadetalle_id})
            </td>
        </tr>
    Next
</table>

<div>
    @Html.ActionLink("Regresar a Maestro de Incidencias", "../empresa_incidenciatipo", "Index")
</div>
