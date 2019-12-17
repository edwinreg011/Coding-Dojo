from flask import Flask, render_template
app = Flask(__name__)

@app.route('/')
def index():
  return render_template('checkerboard.html', number = 8//2)

@app.route('/<int:number>')
def x_loc(number):
  return render_template('checkerboard.html', number = number//2)

if __name__=="__main__":    
    app.run(debug=True)