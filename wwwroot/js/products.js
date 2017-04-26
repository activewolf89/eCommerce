$(document).ready(function(){

    $("img").on("click",function(){
    if (!$(this).parent().attr('data-toggled') || $(this).parent().attr('data-toggled') == 'off'){
        $(this).parent().attr('data-toggled','on');
        // $(this).children("form").show("fast", function(){})
        $(this).siblings(".form").css('display','inline-block');

        var alt = $(this).attr("alt");

      
         $(this).parent().width( 600 ).height(400);
    }
    else if ($(this).parent().attr('data-toggled') == 'on'){
        /* currently it has been toggled, and toggled to the 'on' state,
           so now turn off: */
    
           $(this).parent().width( 200 ).height(200);
           $(this).siblings(".form").css('display','none');
           // and do, or undo, something...\
           $(this).parent().attr('data-toggled','off');
    }
        
    })
});