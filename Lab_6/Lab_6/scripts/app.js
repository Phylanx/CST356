function summary() {
    var first = document.getElementById("first").value;
    var last = document.getElementById("last").value;
    var age = document.getElementById("age").value;
    var standing = document.querySelector('input[name="schoolYear"]:checked').value;

    document.getElementById("name-summary").innerHTML = "Name : " + first + " " + last;
    document.getElementById("age-summary").innerHTML = "Age : " + age;
    document.getElementById("standing-summary").innerHTML = "Standing: " + standing;
}