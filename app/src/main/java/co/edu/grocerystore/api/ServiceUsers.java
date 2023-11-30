package co.edu.grocerystore.api;

import co.edu.grocerystore.model.Register;
import co.edu.grocerystore.model.ResponseCredentials;
import retrofit2.Call;
import retrofit2.http.Body;
import retrofit2.http.POST;

public interface ServiceUsers {
    @POST("register")
    public Call<ResponseCredentials> accesRegister(@Body Register register);
}
