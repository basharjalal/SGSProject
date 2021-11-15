

//function Totoll() {


//    var Qty = document.getElementById('Qty').value;
//    var Price = document.getElementById('Price').value;

//    var Totol = parseFloat(Qty) * parseFloat(Price);
//    document.getElementById('Totol').value = (Totol)

//} 


//var counter = 1;
//$(function () {
//    $('#add').click(function () {
//        $('<tr id="tablerow' + counter + '"><td>' +
//            '<input id="ItemCode" class=" nav-link disabled"  " asp-for="itemsDTL.ItemCode"  name="ItemCode[' + counter + ']"type="text" placeholder="ItemCode" value="jj"  required="required"  />' +
//            '</td>' +
//            '<td>' +
//            '<input id="ItemName" class="form-control  " asp-for="itemsDTL.ItemName"  name="ItemName[' + counter + ']" type="text" placeholder="ItemName"   required="required" " />' +
//            '</td>' +
//            '<td>' +
//            '<input id="Qty" class="form-control  " asp-for="itemsDTL.Qty"  name="Qty[' + counter + '] "type="text" placeholder="Qty"  required="required"  />' +
//            '</td>' +
//            '<td>' +
//            '<input  id="Price" class="form-control  " asp-for="itemsDTL.Price" name="Price[' + counter + ']" type="text" placeholder="Price" oninput="Totoll"  required="required"/>' +
//            '</td>' +
//            '<td>' +
//            '<input  id="Totol" class=" nav-link disabled" type="text" name="Totol[' + counter + '] " placeholder="Totol()"  required="required" onblur="findTotal()"  value="88" /> ' +
//            '</td>' + 
//           '<td>' +
//            '<button type="button" class="btn btn-dange" onclick="removeTr(' + counter + ');"><i class="bi bi-archive"></button>' +
//            '</td>' +
//            '</tr>'            

//        ).appendTo('#submissionTable');

//        counter++;
//        return false;
//    });
//});

//function Totoll() {


//    var Qty = document.getElementsByName('Qty[]').value;
//    var Price = document.getElementsByName('Price[]').value;

//    var Totol = parseFloat(Qty) * parseFloat(Price);
//    document.getElementsByName('Totol[]').value = (Totol)

//}



function removeTr(index) {
    if (counter > 1) {
        $('#tablerow' + index).remove();
        counter--;
    }
    return false;
}

function Submit() {
    if (confirm("Are you sure you want to submit ?")) {
        return true;
    } else {
        return false;
    }
}

