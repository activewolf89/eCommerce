$(document).ready(function(){

    $("button").on("click",function(){
        // alert(this.id);
        var index = this.id
        // console.log($(`#customer_${index}`))
        var user_id = $(`#customer_${index}`).val();
    
        $.ajax({
            type: 'Get',
            url: `/customer/delete/${user_id}`,
            success: function(response)
            {
  
                $(`#${user_id}`).closest('tr').remove();
                
            }
            
        });
    })
    $("#searchtext").bind("keyup",function(){
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
})