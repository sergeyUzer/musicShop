var prevItemId;

function GetAudioPlayer(url, id) {
    var itemId = "#item-" + id;
    $("#audio-hidden").insertAfter($(itemId).find($(".btn-prev")));
    $(itemId).find($(".track-header")).css("margin", "-45px 0 0 14px");
    $("#audio-hidden").css("margin", "-6px -10px");
    $(prevItemId).find($(".btn-prev")).show();
    $(prevItemId).find($(".track-header")).css("margin", "-2px 0 0 0");
    $(itemId).find($(".btn-prev")).hide();
    prevItemId = itemId;
    $("#audio-hidden").show();
    $("#audio-hidden").attr({ "src": url });
}