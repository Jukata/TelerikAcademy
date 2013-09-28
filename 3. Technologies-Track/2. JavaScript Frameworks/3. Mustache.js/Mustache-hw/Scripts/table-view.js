/// <reference path="Scripts/class.js" />
/// <reference path="Scripts/jquery-2.0.3.js" />

var controls = (function () {
    var tableView = Class.create({
        init: function (itemsSource, columns) {
            if (!(itemsSource instanceof Array)) {
                throw "The itemsSoruce of the treeView must be an array!";
            }
            this.itemsSource = itemsSource;
            this.columns = columns | 0;
        },
        render: function (template) {
            var tableHolder = $('<div></div>')
            var table = $('<table class="table-view"></table>');
            tableHolder.append(table);

            var currentRow = $('<tr></tr>');
            table.append(currentRow);

            for (var i = 0; i < this.itemsSource.length; i++) {
                if (i % this.columns == 0) {
                    currentRow = $('<tr></tr>');
                    table.append(currentRow);
                }
                var currentCell = $('<td></td>');
                var currentItem = this.itemsSource[i];
                currentCell.html(template(currentItem));
                currentRow.append(currentCell);
            }

            return tableHolder.html();
        }
    });

    return {
        getTableView: function (itemsSource, columns) {
            return new tableView(itemsSource, columns);
        }
    }
}());