/**
* 
* author : juntao.qiu@gmail.com
* date   : 08/20/2009
*
*/

/**
* This is the list data model, defined
* the style of the list, and all items it contained.
*/
var listDataModel = {
    style: { width: "180px", float: "left" },
    contents: [
		{ content: "您父亲的名字？" },
		{ content: "您父亲的生日？" },
		{ content: "您母亲的名字？" },
		{ content: "您母亲的生日？" },
		{ content: "您配偶的生日？" },
		{ content: "您的出生地？" }
	]
};

/**
* generate the dropdown panel, contains all list items
* and then fulfill the container.
* @dataModel data model of the list items
* @container container of all list items
*/
function buildDropDownList(dataModel, container) {
    var dropdownList = $("<div></div>").addClass("dropdownList_");
    var dropdownPanel = $("<div></div>").addClass("dropdownPanel");
    dropdownList.css("padding-left", "2px").text("--请选择密保问题--");
    dropdownPanel.hide();
    dropdownList.click(function() {
        dropdownPanel.toggle();
    });

    for (var i = 0; i < dataModel.length; i++) {
        var itemContainer = $("<div></div>").addClass("listItemContainer");
        var item = $("<div></div>").addClass("listItem");
        item.text(dataModel[i].content);
        item.mouseover(function() {
            $(this).addClass("selected");
        }).mouseout(function() {
            $(this).removeClass("selected");
        }).click(function() {
            dropdownList.text($(this).text());
            dropdownList
			.css("background", "#fff")
			.css("padding-top", "1px")
			.css("padding-left", $(this).parent().css("padding-left"));
            dropdownPanel.hide();
        });
        dropdownPanel.append(itemContainer.append(item));
    }
    container.append(dropdownList).append(dropdownPanel);
}

/**
* this is the interface for end-user, to use this function, you should provide:
* @datamodel datamodel of the list object
*/
function dropdownList(dataModel) {
    var ddcontainer = $("<div></div>").addClass("dropdownlist");
    for (var p in dataModel.style) { ddcontainer.css(p, dataModel.style[p]); }
    var layout =
		$("<table></table>").attr({ border: "0", cellspacing: "0", cellpadding: "0", width: "100%" });

    var dropdown = $("<tr></tr>");
    //	var listContainerTd = $("<td></td>").addClass("black");
    var listContainerTd = $("<td></td>").attr({ padding: "0", height: "20px" });
    var listContainer = $("<div></div>");

    buildDropDownList(dataModel.contents, listContainer);
    listContainer.appendTo(listContainerTd);
    listContainerTd.appendTo(dropdown);
    var ddicon =
		$("<td></td>").css({ width: "17px", align: "right", height: "18px" }).append(
			$("<div></div>").attr("id", "ddicon").append(
				$("<img />").css({ width: "16px", height: "16px" }).attr("src", "images/dropdownlist_arrow.gif")
			)
		);

    ddicon.children(0).mouseover(function() {
        $(this).children(0).attr("src", "images/dropdownlist_arrow_hov.gif");
    }).mouseout(function() {
        $(this).children(0).attr("src", "images/dropdownlist_arrow.gif");
    }).click(function() {
        listContainer.children(0).click();
    });

    ddicon.appendTo(dropdown);
    dropdown.appendTo(layout);
    layout.append(dropdown);
    layout.appendTo(ddcontainer);

    return ddcontainer;
}

/**
* execute those code when document tree is ready, it'll generate the 
* dropdown list.
*/
$(document).ready(function() {
    var container = $("#list");
    container.append(dropdownList(listDataModel));
    //    $("#click").click(function() {
    //        alert("item [" + $("#list > div > table tr > td > div :first").text() + "] is selected");
    //    });
});
