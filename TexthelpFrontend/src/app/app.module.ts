import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { TexthelpFormComponent } from './texthelp-form/texthelp-form.component';

@NgModule({
  declarations: [
    AppComponent,
    TexthelpFormComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [{ provide: 'BASE_URL', useValue: "https://localhost:7199/Texthelp"}],
  bootstrap: [AppComponent]
})
export class AppModule { }
