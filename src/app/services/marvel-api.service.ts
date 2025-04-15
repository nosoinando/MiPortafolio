import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, of } from "rxjs";

@Injectable({
    providedIn: "root"
})
export class MarvelApiComponent{
    private marvelApiBase = "https://gateway.marvel.com:443/v1/public";
    private apiKey = "ee69488c8d68b3659eab84e47f609612";
    private offset = 0;
    private urlPrefix = `ts=1&apikey=${this.apiKey}&limit=10`
    constructor(private http: HttpClient){}
    getCharacters(next: number) : Observable<any>{
        this.offset = next;
        return this.http.get<any>(`${this.marvelApiBase}/characters?${this.urlPrefix}&offset=${this.offset}`);
    }

    filterCharacters(filter: string, next: number) : Observable<any>{
        return this.http.get<any>(`${this.marvelApiBase}/characters?nameStartsWith=${filter}&${this.urlPrefix}`);
    }

    sortCharacters(param: string, next: number) : Observable<any>{  
        this.offset = next;
        return this.http.get<any>(`${this.marvelApiBase}/characters?orderBy=${param}&${this.urlPrefix}`);
    }

    filterNsortCharacters(filter: string, param: string, next: number) : Observable<any>{
        this.offset = next;
        return this.http.get<any>(`${this.marvelApiBase}/characters?nameStartsWith=${filter}&orderBy=${param}&${this.urlPrefix}`);
    }   

    getComicById(id: string) : Observable<any>{
        return this.http.get<any>(`${this.marvelApiBase}/comics/${id}?${this.urlPrefix}`);
    }

    getCharacterById(id: number) : Observable<any>{
        return this.http.get<any>(`${this.marvelApiBase}/characters/${id}?${this.urlPrefix}`);
    }
}

