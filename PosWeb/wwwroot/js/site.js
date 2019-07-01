//// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
//// for details on configuring this project to bundle and minify static web assets.

//// Write your JavaScript code.
////document.getElementById("SelectCategory").addEventListener("change", SelectedCategory);

let transactionId = document.getElementById("transactionId");

var ALPHABET = '0123456789';
var ID_LENGTH = 4;

var rtn = '';
for (var i = 0; i < ID_LENGTH; i++) {
    rtn += ALPHABET.charAt(Math.floor(Math.random() * ALPHABET.length));
}
transactionId.innerText = rtn;

var count = 0;
var subTotalPrice = 0;

function SelectCategory() {
  
    var CategorySelect = document.getElementById("SelectCategories");
    var SelectedCategory = CategorySelect.options[CategorySelect.selectedIndex].value;
    var data = {
        "CategoryID": SelectedCategory
    }

    var url = "/Sales/GetCategory"
  
    $.ajax({
        type: "Post",
        url: url,
        contentType: "application/json",
        data: JSON.stringify(data),
        success: function (result) {
            var ProductsNameList = $('#productField');
            ProductsNameList.empty();
            for (var i = 0; i < result.length; i++) {
                $('#productField').append($('<option>', {
                    value: result[i].productId,
                    text: result[i].productName

                }));
            }

        }
    })
}

function GetPrice()
{
    var ProductChange = document.getElementById("productField");
    var SelectedProduct = ProductChange.options[ProductChange.selectedIndex].text;

    var data = {
        "Productprice": SelectedProduct
    }
    var url = "/Sales/GetPrice"
    $.ajax({
        type: "Post",
        url: url,  
        contentType: "application/json",
        data: JSON.stringify(data),
        success: function (result) {
            if (result.quantity <= 5 && result.quantity > 0) {
                alert("You have less than 5 ", result.productName);
                var ProductPriceList = $('#priceField');
                ProductPriceList.empty();
                $('#priceField').append(result.amount);
            }
            if (result.quantity == 0) {
                alert("This product is not avaiable anymore in stock");

                document.getElementById("priceField").innerHTML = "";
               
            }
            else
            {
                var ProductPriceList = $('#priceField');
                ProductPriceList.empty();
                $('#priceField').append(result.amount);
            }
        }
    })
}


function AddProduct()
{
    var customer = document.getElementById("customer");
    var currentCustomerVal = customer.options[customer.selectedIndex].value;
    var currentCustomer = customer.options[customer.selectedIndex].text;


    var product = document.getElementById("productField");
    var currentProductVal = product.options[product.selectedIndex].value;
    var currentProduct = product.options[product.selectedIndex].text;

    var price = document.getElementById("priceField").innerText;

    var quantity = document.getElementById("quantity").value;

    var productTable = document.getElementById("productsDisplayTable");

    var SubTotalField = document.getElementById("subTotalField");

    //let transactionId = document.getElementById("transactionId").value;

    let transactionIdOut = document.getElementById("transactionId").innerText;
    //calculate the subtotal
    subTotalPrice = price * quantity;
    SubTotalField.innerHTML = subTotalPrice;
    
    if (count == 0) {
    //getting and displaying the subTotal
    subTotalPrice = price * quantity;
    var subTotal = document.getElementById("grandTotalField");
    subTotal.innerText = subTotalPrice;
    }

    if (count > 0) {
        subTotalPrice = price * quantity;
        var subTotal = document.getElementById("grandTotalField").innerText;
        var subTotal2 = parseFloat(subTotal) + parseFloat(subTotalPrice);
        var st = $('#grandTotalField');
        st.empty();
        $("#grandTotalField").append($('<span>', {
            text: subTotal2
        }));
    }

    count = count + 1

    var row = productTable.insertRow(0);

    var td1 = row.insertCell(0);
    var td2 = row.insertCell(1);
    var td3 = row.insertCell(2);
    var td4 = row.insertCell(3);
    var td5 = row.insertCell(4);
    var td6 = row.insertCell(5);
    var td7 = row.insertCell(6);
    var td8 = row.insertCell(7);
    var td9 = row.insertCell(8);

    //td3.innerHTML = '<div id="hideCus">' + currentCustomerVal + '</div>';
    //td4.innerHTML = currentProduct;
    //td5.innerHTML = '<div id="hidePro">' + currentProductVal + '</div>';

    td1.innerHTML = transactionIdOut;
    td2.innerHTML = currentCustomer;
    td3.innerHTML = currentCustomerVal;
    td4.innerHTML = currentProduct;
    td5.innerHTML = currentProductVal;
    td6.innerHTML = price;
    td7.innerHTML = quantity;
    td8.innerHTML = subTotalPrice;
    td9.innerHTML = '<input class="btn btn-warning btn-sm" type="button" value="Remove" onclick="Remove(this)"/>';

    //var tableCus = document.getElementById("hideCus");
    //var tablePro = document.getElementById("hidePro");

    //tableCus.style.visibility = 'hidden';
    //tablePro.style.visibility = 'hidden';

    document.getElementById("SelectCategories").value = "";
    document.getElementById("productField").value = "";
    document.getElementById("quantity").value = "";
    //document.getElementById("SubTotalField").value = "";



}

function createSales() {

    //Get values and texts from input
    let grandTotal = document.getElementById("grandTotalField").innerText;
    let amountDue = document.getElementById("amountDueField").value;
    let balance = document.getElementById("balanceField");
    let transactionId = document.getElementById("transactionId");

    //Calculate grandtotal and pass to balance text field
    let balanceAmt = grandTotal - amountDue;
    balance.innerHTML = balanceAmt;


    //Calculate the date
    let table = document.getElementById("productsDisplayTable").innerText;
    today = new Date();
    var dd = today.getDate();

    //Create an empty are of sales
    var sales = new Array();

    //get items from the table, create a new object and push to array
    $("#salesTable tbody tr").each(function () {
        var row = $(this);
        var ListSales = {};
        ListSales.TransactionId = row.find("td").eq(0).html();
        ListSales.CustomerName = row.find("td").eq(1).html();
        ListSales.CustomerId = row.find("td").eq(2).html();
        ListSales.ProductName = row.find("td").eq(3).html();
        ListSales.productId = row.find("td").eq(4).html();
        ListSales.Price = row.find("td").eq(5).html();
        ListSales.QuantityPurchased = row.find("td").eq(6).html();
        ListSales.TotalPrice = row.find("td").eq(7).html();

        sales.push(ListSales);
    });
       
    //send data to controller
    var url = "/Sales/AddProduct"
    $.ajax({
        type: "Post",
        url: url,
        data: JSON.stringify(sales),
        contentType: "application/json; charset=utf - 8",
        dataType: "json",
        success: function (result) {
            alert(result + "Record added");
        },
        error: function (err) {
             alert(err);
        }
    });

 

    //Create data for sale details output
    //after buy button is clicked save data to salesoutput
    var grandTotalout = document.getElementById("grandTotalField").innerText;
    var amountPaidout = document.getElementById("amountDueField").value;
    var balanceout = document.getElementById("balanceField").innerText;
    var transactionIdout = document.getElementById("transactionId").innerText;
    var staffout = document.getElementById("staff").value;

    var customerIn = document.getElementById("customer");
    //var currentCustomerVal = customerIn.options[customerIn.selectedIndex].value;
    var currentCustomerOut = customerIn.options[customerIn.selectedIndex].text;

    var today = new Date();
    var dd = String(today.getDate()).padStart(2, '0');
    var mm = String(today.getMonth() + 1).padStart(2, '0'); //January is 0!
    var yyyy = today.getFullYear();

    today = mm + '/' + dd + '/' + yyyy;

    var CalulateSales = new Array();
    var BalanceItems = {};

    BalanceItems.TransactionId = transactionIdout;
    BalanceItems.TotalAmountDue = grandTotalout;
    BalanceItems.TotalAmountPaid = amountPaidout;
    BalanceItems.Balance = balanceout;
    BalanceItems.TransactionStaff = staffout;
    BalanceItems.CustomersName = currentCustomerOut;
    BalanceItems.SalesDate = today;
    CalulateSales.push(BalanceItems);

  
    var url = "/SalesOutputs/AddProductCalculations"
    $.ajax({
        type: "Post",
        url: url,
        data: JSON.stringify(CalulateSales),
        contentType: "application/json; charset=utf - 8",
        dataType: "json",
        success: function (result) {
            alert(result + "Record added");
        },
        error: function (err) {
            alert(err);
        }
    });

    //update product availability
    var productsQuantity = new Array();

    $("#salesTable tbody tr").each(function () {
        var row = $(this);
        var productsQuantityObj = {};
        productsQuantityObj.productId = row.find("td").eq(4).html();
        productsQuantityObj.QuantityPurchased = row.find("td").eq(6).html();
        productsQuantity.push(productsQuantityObj);
    });
    var url = "/Products/UpdateProductLevel"
    debugger
    $.ajax({
        type: "Post",
        url: url,
        data: JSON.stringify(productsQuantity),
        contentType: "application/json; charset=utf - 8",
        dataType: "json",
        success: function (result) {
            alert(result + "Record added");
        },
        error: function (err) {
            alert(err);
        }
    }); 
}


function Remove(button) {
    //Determine the reference of the Row using the Button.
    var row = $(button).closest("tr");
    var name = $("td", row).eq(0).html();
    if (confirm("Do you want to delete: " + name)) {
        //Get the reference of the Table.
        var table = $("#salesTable")[0];


        var deletedPriceRow = $("td", row).eq(7).html();
        var currentGrandTotal = document.getElementById("grandTotalField").innerText;
        var newTotal = currentGrandTotal - deletedPriceRow;
        //console.log("This is the deletedRow price", deletedPriceRow);
        //console.log("This is the current grand total", currentGrandTotal);

        grandTotalField.innerText = newTotal;

        //Delete the Table row using it's Index
        table.deleteRow(row[0].rowIndex);

   
      
    }
};
