mergeInto(LibraryManager.library, {

  Hello: function () {
    window.alert("Hello, world!");
  },

  SaveExtern: function(date){
    var dateString = UTF8ToString(date);
    var myobj = JSON.Parse(dateString);
    player.setData(myobj);
  },

  LoadExtern: function(){
    player.getData().then(_date => {
      const myJSON = JSON.stringify(_date);
      myGameInstance.SendMessage('Progress', 'Load', myJSON);
    });
  },

  SaveExternPurchase: function(newDate){
    var dateStringPurchase = UTF8ToString(newDate);
    var myobjPurchase = JSON.Parse(dateStringPurchase);
    player.setData(myobjPurchase);
  },

  LoadExternPurchase: function(){
    player.getData().then(_newDate => {
      const myJSONPurchase = JSON.stringify(_newDate);
      myGameInstancePurchase.SendMessage('TankPurchased', 'LoadPurchase', myJSONPurchase);
    });
  },

});