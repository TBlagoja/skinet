import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import{ HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CoreModule } from './core/core.module';
import { ShopService } from './shop/shop.service';
import { HomeModule } from './home/home.module';
import { ErrorsInterceptor } from './core/interceptors/errors.interceptor';
import { LoadingInterceptor } from './core/interceptors/loading.interceptor';

@NgModule({
  declarations: [
    AppComponent
    ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    CoreModule,
    HomeModule
  ],  
  providers: [
    ShopService,
    {provide:HTTP_INTERCEPTORS, useClass: ErrorsInterceptor, multi: true},
    {provide:HTTP_INTERCEPTORS, useClass: LoadingInterceptor, multi: true},
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
