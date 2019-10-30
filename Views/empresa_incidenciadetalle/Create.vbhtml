@ModelType mmpLibrerias.empresa_incidenciadetalle
@Code
    ViewData("Title") = "Create"
    Layout = "~/Views/Shared/_Layout.vbhtml"


    Dim _incidencia As String = 2


End Code

<h2>Creando Detalle de Incidencia</h2>

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()

    @<div class="form-horizontal">
    <hr />
    <div class="form-group">
        @Html.LabelFor(Function(model) model.incidenciatipo_id, "Tipo de Incidencia", htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.DropDownList("incidenciatipo_id", Nothing, htmlAttributes:=New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(model) model.incidenciatipo_id, "", New With {.class = "text-danger"})
        </div>
    </div>

    (SelectList)ViewData["UserId"])

  


    <div class="form-group">
        @Html.LabelFor(Function(model) model.incidenciadetalle_nombre_txt, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.EditorFor(Function(model) model.incidenciadetalle_nombre_txt, New With {.htmlAttributes = New With {.class = "form-control"}})
            @Html.ValidationMessageFor(Function(model) model.incidenciadetalle_nombre_txt, "", New With {.class = "text-danger"})
        </div>
    </div>
    <div class="form-group">
        <div class="col-md-offset-2 col-md-10">
            <input type="submit" value="Crear" class="btn btn-default" onclick="location.href='../ClientSide/Registration/registration.aspx'" />
        </div>
    </div>
</div>
End Using

<div>
    @code
        Dim _id As Long = Url.RequestContext.RouteData.Values("id")
    End Code
    @Html.ActionLink("Regresar", "Index", New With {.id = _id})
</div>

@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section