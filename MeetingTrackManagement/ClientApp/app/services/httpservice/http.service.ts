import { Injectable, Injector } from "@angular/core";
import { Http, Headers } from "@angular/http";

@Injectable()

export class HttpService {
    baseUri = "http://localhost:5000/api/";
    
    constructor(private http: Http) {

    }

    post(data: any, endpoint: string) {
        let headers = new Headers();
        headers.append("Content-Type","application/x-www-form-urlencoded")

        return this.http.post(this.fullurl(endpoint),
                              this.encodeObject(data).toString(),
                              { headers: headers }
                              )
    }

    get(endpoint: string) {
        return this.http.get(this.fullurl(endpoint))
    }

    private fullurl(uri: string): string {
        return `${this.baseUri}${uri}`;
    }

    private encodeObject(obj: any): URLSearchParams {
        let params: URLSearchParams = new URLSearchParams();
        for (var key in obj) {
            if (obj.hasOwnProperty(key)) {
                params.append(key, obj[key]);
            }
        }
        return params;
    }
}