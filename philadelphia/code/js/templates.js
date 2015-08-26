/**
 * Created by Terry on 2015-08-25.
 */

var source   = $("#apply-btn-template").html();
var template = Handlebars.compile(source);

var context = {label: "", button: "Zgłoś się!"};
var html = template(context);

$("#apply-btn-placeholder").html(html);


