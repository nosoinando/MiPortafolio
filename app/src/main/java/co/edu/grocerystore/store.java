package co.edu.grocerystore;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;

public class store extends AppCompatActivity {

    private Button btnLogout;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_store);
        begin();
        this.btnLogout.setOnClickListener(this::main);
    }

    private void main(View view) {
        Intent goMain = new Intent(getApplicationContext(), MainActivity.class);
        startActivity(goMain);
    }

    private void begin(){
        this.btnLogout= findViewById(R.id.btnLogout);
    }
}