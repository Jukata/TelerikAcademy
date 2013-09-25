var Student = function (fname, lname, grade) {
    this.fname = fname;
    this.lname = lname;
    this.grade = grade;
}

var GenerateTableOfStudents = function (selector, array) {
    var tableHolder = $(selector);

    var table ='<table class="students-table">\
                  <thead>\
                    <tr>\
                        <th>First name</th>\
                        <th>Last name</th>\
                        <th>Grade</th>\
                    </tr>\
                   </thead>';
    if (array.length > 0) {
        table+='<tbody>';
        for (var i = 0; i < array.length; i++) {
            table+="<tr>\
                        <td>" + array[i].fname + "</td>\
                        <td>" + array[i].lname + "</td>\
                        <td>" + array[i].grade + "</td>\
                    </tr>";
        }

        table+='</tbody>';
    }
    table += '</table>';
    tableHolder.append(table);
}