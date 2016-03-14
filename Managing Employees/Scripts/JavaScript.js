function DeleteEmployee(E_ID) {  
    if (confirm("Are You Sure Delete Selected Employee Record No.? " + E_ID)) {  
        var data = { 'EmpID': E_ID }  
        $.post('/EmployeeInfo/Delete', data,  
        function (data) {  
            if (data == true)  
                location = location.href;  
            else  
                alert("Not delete something Wrong");  
        });  
    }   