package co.edu.grocerystore.entities;

import java.io.Serial;
import java.io.Serializable;

public class Person implements Serializable {
    private String name;
    private String lastname;
    private String doctype;
    private String docnumber;
    private String address;
    private String email;
    private String phone;
    private String password;

    public Person(String name, String lastname, String doctype, String docnumber, String address, String email, String phone, String password) {
        this.name = name;
        this.lastname = lastname;
        this.doctype = doctype;
        this.docnumber = docnumber;
        this.address = address;
        this.email = email;
        this.phone = phone;
        this.password = password;
    }

    public String getAddress() {
        return address;
    }

    public void setAddress(String address) {
        this.address = address;
    }

    public Person() { }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getLastname() {
        return lastname;
    }

    public void setLastname(String lastname) {
        this.lastname = lastname;
    }

    public String getDoctype() {
        return doctype;
    }

    public void setDoctype(String doctype) {
        this.doctype = doctype;
    }

    public String getDocnumber() {
        return docnumber;
    }

    public void setDocnumber(String docnumber) {
        this.docnumber = docnumber;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public String getPhone() {
        return phone;
    }

    public void setPhone(String phone) {
        this.phone = phone;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }

    @Override
    public String toString() {
        return "Person{" +
                "name='" + name + '\'' +
                ", lastname='" + lastname + '\'' +
                ", doctype='" + doctype + '\'' +
                ", docnumber='" + docnumber + '\'' +
                ", email='" + email + '\'' +
                ", phone='" + phone + '\'' +
                ", password='" + password + '\'' +
                '}';
    }
}
