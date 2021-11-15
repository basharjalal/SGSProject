
//function Totolll() {


//    var Qty = document.getElementById('Qty').value;
//    var Price = document.getElementById('Price').value;

//    var Totol = parseFloat(Qty) * parseFloat(Price);
//    document.getElementById('Totol').value = (Totol)

//} 

var a = $(document).ready(function () {
    $(".calcTotal").blur(function () {
        var rowNum = this.getAttribute("data-id");
        var qty = 0;
        var price = 0;
        if ($("#Qty[data-id=" + rowNum + "]") != undefined) {
            qty = $("#Qty[data-id=" + rowNum + "]").val();
            price = $("#Price[data-id=" + rowNum + "]").val();
        }
        console.log(qty + "," + price);
        if (price > 0 && qty > 0) {
            if ($("#Totol[data-id=" + rowNum + "]") != undefined) {
                $("#Totol[data-id=" + rowNum + "]").val(parseFloat(qty) * parseFloat(price));
            }
        }
    });
});
var counter = 1;
$(function () {
    $('#aadd').click(function () {

        $(' <tr id="tablerow' + counter + '"><td>' +
            '<input id="ItemCode[' + counter + ']" class=" nav-link disabled"  " asp-for="itemsDTL.ItemCode"  name="ItemCode" type="text" placeholder="ItemCode" value="jj"  required="required"  />' +
            '</td>' +
            '<td>' +
            '<input id="ItemName[' + counter + ']" class="form-control  " asp-for="itemsDTL.ItemName"  name="ItemName" type="text" placeholder="ItemName"   required="required" " />' +
            '</td>' +
            '<td>' +
            '<input id="Qty[' + counter + ']" data-id='+counter +' class="form-control  " asp-for="itemsDTL.Qty"  name="Qty "type="text" placeholder="Qty"  required="required"  />' +
            '</td>' +
            '<td>' +
            '<input  id="Price[' + counter + ']" data-id=' + counter +' class="form-control  " asp-for="itemsDTL.Price" name="Price" type="text" placeholder="Price"  required="required"/>' +
            '</td>' +
            '<td>' +
            '<input  id="Totol[' + counter + ']"  data-id=' + counter +' class=" nav-link disabled" type="text" name="Totol " placeholder="Totol()"  required="required" onblur="findTotal()"  value="88" /> ' +
            '</td>' +
            '<td>' +
            '<button type="button" class="btn btn-dange" onclick="removeTr(' + counter + ');"><i class="bi bi-archive"></button>' +
            '</td>' +
            '</tr>'

        ).appendTo('#submissionTable');

        counter++;
        return false;
    });
});
function removeTr(index) {
    if (counter > 1) {
        $('#tablerow' + index).remove();
        counter--;
    }
    return false;
}