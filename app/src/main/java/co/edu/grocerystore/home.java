package co.edu.grocerystore;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

import co.edu.grocerystore.entities.Person;

public class home extends AppCompatActivity {

    private TextView tvWelcome;
    private Button btnWelcome;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_home);
        begin();
        receiver();
        this.btnWelcome.setOnClickListener(this::store);
    }

    private void store(View view) {
        Intent goStore = new Intent(getApplicationContext(), store.class);
        startActivity(goStore);
    }

    private void begin(){
        this.tvWelcome = findViewById(R.id.tvWelcome);
        this.btnWelcome = findViewById(R.id.btnContinueHome);
    }

    private void receiver(){
        Bundle data = getIntent().getExtras();
        Person person = new Person();
        person = (Person) data.get("person");
        tvWelcome.setText("!Bienvenido¡ " + person.getName() + " " + person.getLastname() + " a nuestra app la familia de Pl@neta Papel esta complacida de tenerte.");
    }
}