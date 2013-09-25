var GridView = (function () {
    // Private function
    function onRowClick (e) {
        var row = $(this).next();
        if (row.attr("data-inner")) {
            if (row.is(":visible")) {
                row.hide();
            } else {
                row.show();
            }
        }

        e.stopPropagation();
        e.preventDefault();
    }

    function GridViewControl(container) {
        this.container = container;
        this.table = $("<table></table>");
        this.thead = $("<thead></thead>");
        this.tbody = $("<tbody></tbody>");
    }

    GridViewControl.prototype.render = function () {
        this.table.append(this.thead);
        this.table.append(this.tbody);
        this.container.append(this.table);
    };

    GridViewControl.prototype.addRow = function () {
        if (!this.cellLength) {
            this.cellLength = arguments.length;
        }

        var row = $("<tr></tr>");
        row.click(onRowClick);
        for (var i = 0; i < this.cellLength; i++) {
            row.append("<td>" + arguments[i] + "</td>");
        }

        this.tbody.append(row);
        var grid = new GridView(row);
        return grid;
    };

    GridViewControl.prototype.addHeader = function () {
        if (!this.cellLength) {
            this.cellLength = arguments.length;
        }

        var row = $("<tr></tr>");
        for (var i = 0; i < this.cellLength; i++) {
            row.append("<th>" + arguments[i] + "</th>");
        }

        this.thead.html(row);
    };

    GridViewControl.prototype.addNestedTable = function () {
        var row = this.container;
        var tr = $("<tr data-inner='true'><td style='display: inline-table' colspan='" +
            $("td", row).length + "'></td></tr>");
        tr.insertAfter(row);
        tr.hide();
        this.container = $("td", tr);
        this.render();
    };

    return GridViewControl;
}());
