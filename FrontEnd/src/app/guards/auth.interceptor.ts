import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
 
@Injectable()
export class AuthInterceptor implements HttpInterceptor {
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    
    const headers = new HttpHeaders({
        'Authorization': 'Bearer avinal',
        'Content-Type': 'application/json',
    })

    const authReq = req.clone({headers});
 

    

    // send the newly created request
    return next.handle(authReq);
  }
}