import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { NgModel } from "@angular/forms";
import { JwtHelperService } from "@auth0/angular-jwt";
import { Observable } from "rxjs";


@Injectable()
export class AuthInterceptor implements HttpInterceptor {
    
    constructor(private jwtHelper: JwtHelperService){ }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

        const token = localStorage.getItem("id_token");
        
        if (token) {
            if(this.jwtHelper.isTokenExpired(token)){
                alert("Token expired");
                localStorage.removeItem("id_token");
                return next.handle(req);
            }
            else
            {
                const cloned = req.clone({
                    headers: req.headers.set("Authorization",
                        "Bearer " + token)
                });
        
                return next.handle(cloned);
            }
        
        }
        else {
            return next.handle(req);
        }
}
}