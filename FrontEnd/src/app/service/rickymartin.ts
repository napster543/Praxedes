import { HttpClient, HttpHeaders, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, Subject, catchError, retry, tap, throwError } from "rxjs";
import { response } from "../interface/response";
import { Usuario } from "../interface/usuario/usuario";
import { UsuarioResponse } from "../interface/usuario/usuario-response";
import { UsuarioDto } from "../interface/usuario/usuario-dto";
import {  Episode } from "../interface/episode";

@Injectable({
    providedIn: 'root'
})

export class RickyService{
  
    
    private apiURL:  string = "";   
    
    constructor(private _httpservice: HttpClient){        
        this.apiURL = "https://rickandmortyapi.com/api/";         
    } 
   
      GetEpisodio(): Observable<Episode> {
        return this._httpservice.get<Episode>(this.apiURL + 'episode').pipe(retry(2), catchError(this.handleError))
      }  

      
      handleError(error) {
        let errorMessage = ''; 
        if(error.error instanceof ErrorEvent) {
          // Get client-side error
          errorMessage = error.error.message;
        } else {
          if(error.status === 404){
            errorMessage = "Error 404 Se presento un problema con el consumo de la información \n POR FAVOR REPORTAR AL ADMINISTRADOR";
          }
          //errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
          console.log(`Error Code: ${error.status}\nMessage: ${error.message}`)
            
        }
        window.alert(errorMessage);
        return throwError(errorMessage);
      }
         


}

