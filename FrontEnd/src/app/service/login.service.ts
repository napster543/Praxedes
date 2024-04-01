import { HttpClient, HttpHeaders, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, Subject, catchError, retry, tap, throwError } from "rxjs";
import { response } from "../interface/response";
import { Usuario } from "../interface/usuario/usuario";
import { UsuarioResponse } from "../interface/usuario/usuario-response";
import { UsuarioDto } from "../interface/usuario/usuario-dto";

@Injectable({
    providedIn: 'root'
})

export class LoginService{
  
    public urlUsuarioIntentaAcceder = '';
    private apiURL:  string = "";   
    public changeLoginStatusSubject = new Subject<boolean>();
    public changeLoginStatus$ = this.changeLoginStatusSubject.asObservable(); 
    readonly TOKENVALIDO = 'TOKEN';
    readonly ISLOGGEDKEY = 'islogged';

    constructor(private _httpservice: HttpClient){        
        this.apiURL = "http://localhost:24744/api/";         
    } 
   
      GetUsuarioLogin(registro:Usuario): Observable<UsuarioResponse> {
        return this._httpservice.post<UsuarioResponse>(this.apiURL + 'Usuario/login', registro, {
                          headers:  new HttpHeaders()                                    
                                        .set("Content-Type", "application/json") 
                }).pipe(
                  tap((dt: UsuarioResponse) =>{
                    if(dt.success){
                      console.log("inicio", dt.data.token);
                      
                      
                      console.log("fin");
                      localStorage.setItem(this.ISLOGGEDKEY, 'true');
                      localStorage.setItem(this.TOKENVALIDO, dt.data.token);
                      this.changeLoginStatusSubject.next(true);
                    }else{
                      localStorage.setItem(this.ISLOGGEDKEY, 'false');
                      localStorage.removeItem(this.TOKENVALIDO);
                    }
                  })
                )   
      }  

      RegistrarUsuario(registro:UsuarioDto): Observable<response> {
        return this._httpservice.post<response>(this.apiURL + 'Usuario/Create', registro)
            .pipe(retry(4), catchError(this.handleError)); 
      }
    

      isLoggedIn(url:string):boolean{
        const isLogged = localStorage.getItem(this.ISLOGGEDKEY);
        
        //debugger;
        if(!isLogged){
          this.urlUsuarioIntentaAcceder = url;
          return false;
        }
        return true;
      }
    
      logout(){
        localStorage.removeItem(this.ISLOGGEDKEY);
        localStorage.removeItem(this.TOKENVALIDO);
        localStorage.removeItem("VerUsuario");
        localStorage.removeItem("DBodega");
        localStorage.removeItem("DTipo");
        this.changeLoginStatusSubject.next(false);  
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

