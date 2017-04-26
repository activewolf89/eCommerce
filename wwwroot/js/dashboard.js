$(document).ready(function(){

    $("#showmoreproduct").click(function(e){
         e.preventDefault();
         $.ajax({
    type: 'Get',
    url: '/showmoreproduct',
    success: function(response)
        {
            // console.log(response.myProducts);
            $("#forloop").hide();
            $.each(response.myProducts,function(index,value){
                console.log(value);
                $('#productallloop')
                .append(`<div class = "adjustedimage"> 
                <img src = ${value.imgSrc}>
                <h3>${value.productName}</h3>
                <h3>(${value.quantity}) left</h3> </div>`);
                
            })
        }
         })
    })
})