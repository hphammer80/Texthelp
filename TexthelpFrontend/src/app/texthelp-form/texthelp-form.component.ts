import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';

@Component({
  selector: 'app-texthelp-form',
  templateUrl: './texthelp-form.component.html',
  styleUrls: ['./texthelp-form.component.css']
})
export class TexthelpFormComponent implements OnInit {


  public locales: Locale[] = [{name: "da-DK", selected: true}, {name: "en-GB", selected: false}];
  public text: string = "";
  public result: WordPredictionsResults = {} as WordPredictionsResults;

  constructor(private http: HttpClient, @Inject("BASE_URL") private baseUrl: string) { 
    
  }

  ngOnInit(): void {
  }

  radioChecked(name: string){
    this.locales.forEach(item=>{
      if(item.name !== name){ 
         item.selected = false;
      }else{
         item.selected = true;
      } 
    })
  }

  textareaKeyPressed(){
    let selectedLocale = this.getSelectedLocale();
    console.log(this.text);
    let params = new HttpParams({fromObject: { locale: selectedLocale, text: this.text }});
    this.http.get<WordPredictionsResults>(this.baseUrl, {params: params}).subscribe(result => {
      this.result = result;
    })
  }

  getSelectedLocale(): string{
    let locale = "";
    this.locales.forEach(item => {
      if (item.selected){
        locale = item.name;
      }
    });
    return locale;
  }

  listClick(word: string) {
    let words = this.text.split(" ");
    let newWords: string[] = [];
    words.forEach(w => {
      if (words.indexOf(w) !== words.length - 1){
        newWords.push(w);
      }
    })
    newWords.push(word);
    this.text = newWords.join(" ");
  }
}

interface Locale{
  name: string;
  selected: boolean;
}

interface WordPredictionsResults{
  wordPredictions: string[];
  dictionaryItems: string[];
}
