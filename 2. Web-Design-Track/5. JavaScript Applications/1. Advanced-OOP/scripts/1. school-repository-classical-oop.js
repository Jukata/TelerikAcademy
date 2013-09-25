var schoolRepository = (function () {

    var School = {
        init: function (name, town, courses) {
            this.name = name;
            this.town = town;
            this.courses = [];
            for (var i = 0; i < courses.length; i++) {
                this.courses.push(courses[i]);
            }
        },

        introduce: function () {
            var toString = "Name: " + this.name + ", Town: " + this.town;
            if (this.courses.length > 0) {
                toString += "\nClasses:\n";
                for (var i = 0; i < this.courses.length; i++) {
                    toString += (i + 1) + ". " + this.courses[i].introduce() + "\n";
                }
            }
            return toString;
        },

        addCourse: function (course) {
            this.courses.push(course);
        },
    };

    var Course = {
        init: function (name, students, capacity, formTeacher, teachers) {
            this.name = name;
            this.formTeacher = formTeacher;
            this.capacity = capacity;
            this.students = [];
            for (var i = 0; i < students.length; i++) {
                this.students.push(students[i]);
            }
            this.teachers = [];
            for (var i = 0; i < teachers.length; i++) {
                this.teachers.push(teachers[i]);
            }
        },

        addStudent: function (student) {
            this.students.push(student);
        },

        addTeacher: function (teacher) {
            this.teachers.push(teacher);
        },

        addFormTeacher: function (teacher) {
            this.formTeacher = teacher;
        },

        introduce: function () {
            var toString = "Name: " + this.name + ", Capacity: " + this.capacity + "\nForm teacher: " + this.formTeacher.introduce();

            if (this.students.length > 0) {
                toString += "\nStudents:\n";
                for (var i = 0; i < this.students.length; i++) {
                    toString += (i + 1) + ". " + this.students[i].introduce() + "\n";
                }
            }
            if (this.teachers.length > 0) {
                toString += "Teachers:\n"
                for (var i = 0; i < this.teachers.length; i++) {
                    toString += (i + 1) + ". " + this.teachers[i].introduce() + "\n";
                }
            }
            return toString;
        }
    };


    var Person = {
        init: function (fname, lname, age) {
            this.fname = fname;
            this.lname = lname;
            this.age = age;
        },

        introduce: function () {
            return "Fname: " + this.fname + ", Lname: " + this.lname + ", Age: " + this.age;
        }
    }

    var Student = {
        init: function (fname, lname, age, grade) {
            Person.init.apply(this, arguments);
            this.grade = grade;
        },

        introduce: function () {
            return Person.introduce.apply(this) + ", Grade: " + this.grade;
        }
    }

    var Teacher = {
        init: function (fname, lname, age, speciality) {
            Person.init.apply(this, arguments);
            this.speciality = speciality;
        },

        introduce: function () {
            return Person.introduce.apply(this) + ", Speciality: " + this.speciality;
        }
    }

    return {
        School: School,
        Course: Course,
        Person: Person,
        Student: Student,
        Teacher: Teacher,
    }
})();


