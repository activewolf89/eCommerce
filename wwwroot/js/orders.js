$(document).ready(function(){
var productArray = [];
$.ajax({
    type: 'Get',
    url: '/initialorders',
    success: function(response)
    {
        var toAppend = '';
        $.each(response.customer,function(i,o){

            toAppend += '<option>'+o.customerName+'</option>';
        })
        $('#customer').append(toAppend)


        var toAppendTwo = '';
        $.each(response.product,function(i,x){
            productArray.push(x);
            toAppendTwo += '<option>'+x.productName+'</option>';
        })
        $('#product').append(toAppendTwo)
        
        var toAppendThree = '';
        var productCount = response.product[0].quantity; 

        for(var i = 1; i < productCount+1;i++)
        {
              toAppendThree += '<option>'+i+'</option>';

        }
        $('#order').append(toAppendThree);
     
    }

});
$('#product').change(function(){
var newProductQuantity;
var toAppendFour = '';

   for(var i = 0; i < productArray.length; i++)
   {

       if(productArray[i].productName == $("#product").val())
       {
            newProductQuantity = productArray[i].quantity;
       };
   }
   for(var i = 1; i < newProductQuantity+1;i++)
   {

       toAppendFour += '<option>'+i+'</option>';
   }
   $('#order').empty().append(toAppendFour);
})
    $("#order_filter").bind("keyup",function(){
        var filter = $(this).val();
     $("table tr").each(function(index){
         if (index !=0)
         {
             $row = $(this);
             var id = $row.find("td:first").text();
             if(id.indexOf(filter) == -1)
             {
                 $(this).hide();
             }
             else 
             $(this).show();
         }
     })
    })
});